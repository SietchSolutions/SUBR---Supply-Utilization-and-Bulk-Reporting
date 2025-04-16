using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class GoogleSheetsHelper
{
    public static SheetsService service;
    public static string spreadsheetId = "1I2ijrahdGS3iMUjCp9dnWQkuOT4wxst38wvT26q41_w";

    public static void Init()
    {
        var credential = GoogleCredential.FromFile("Keys/service-key.json")
                          .CreateScoped(SheetsService.Scope.Spreadsheets);
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "SUBR"
        });
    }
    public static List<string> GetAllStationTypes()
    {
        var request = service.Spreadsheets.Values.Get(spreadsheetId, "Templates!A2:A");
        var response = request.Execute();

        return response.Values?
            .Select(row => row[0].ToString())
            .Distinct()
            .OrderBy(type => type)
            .ToList() ?? new List<string>();
    }

    public static List<(string Material, int Required, int Delivered, int Remaining)> GetStationMaterials(string stationName)
    {
        var request = service.Spreadsheets.Values.Get(spreadsheetId, "Requirements!A2:E");
        var result = request.Execute();

        return result.Values?
            .Where(row => row.Count >= 3 && row[1].ToString().Equals(stationName, StringComparison.OrdinalIgnoreCase))
            .Select(row =>
            {
                string name = row[2].ToString(); // Material
                int req = int.TryParse(row[3].ToString(), out var r) ? r : 0;
                int del = int.TryParse(row[4].ToString(), out var d) ? d : 0;
                int rem = req - del;
                return (name, req, del, rem);
            }).ToList() ?? new List<(string, int, int, int)>();
    }




    public static void CreateStationFromTemplate(string systemName, string stationName, string stationType, string commanderName)

    {
        // service and spreadsheetId are already set up at the class level via Init()
        var templateRequest = service.Spreadsheets.Values.Get(spreadsheetId, "Templates!A2:C");
        var templateResponse = templateRequest.Execute();
        var templateRows = templateResponse.Values;

        if (templateRows == null)
        {
            Console.WriteLine("❌ No templates found.");
            return;
        }

        var filtered = templateRows
            .Where(row => row.Count >= 3 && row[0].ToString().Trim().Equals(stationType, StringComparison.OrdinalIgnoreCase))
            .Select(row => new {
                Material = row[1].ToString(),
                Required = int.TryParse(row[2].ToString(), out var val) ? val : 0
            })
            .Where(t => t.Required > 0)
            .ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine($"⚠ No matching templates found for type '{stationType}'");
            return;
        }

        var newRows = new List<IList<object>>();
        foreach (var entry in filtered)
        {
            newRows.Add(new List<object>
        {
            systemName,
            stationName,
            entry.Material,
            entry.Required,
            0
        });
        }

        var range = "Requirements!A:E";
        var valueRange = new ValueRange { Values = newRows };

        var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
        LogStationMetadata(stationName, systemName, stationType, commanderName);
        Console.WriteLine($"✅ Created requirements for '{stationName}' in system '{systemName}'");
    }
    public static void LogCommander(string commander, string squadron, string lastSeen)
    {
        var range = "Commanders!A2:C";
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();
        var rows = response.Values;

        if (rows == null)
            rows = new List<IList<object>>();

        int rowIndex = 2; // Start at row 2 (after headers)
        bool found = false;

        foreach (var row in rows)
        {
            if (row.Count < 1) continue;

            string existingCommander = row[0].ToString();

            if (existingCommander == commander)
            {
                // ✅ Commander already exists, update LastSeen
                string updateRange = $"Commanders!C{rowIndex}";
                var updateValues = new ValueRange
                {
                    Values = new List<IList<object>> { new List<object> { lastSeen } }
                };

                var updateRequest = service.Spreadsheets.Values.Update(updateValues, spreadsheetId, updateRange);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                updateRequest.Execute();

                found = true;
                break;
            }

            rowIndex++;
        }

        if (!found)
        {
            // ✅ New commander — insert full row
            var newRow = new List<object> { commander, squadron, lastSeen, 0 }; // Start with TotalTransferred = 0
            var append = new ValueRange
            {
                Values = new List<IList<object>> { newRow }
            };

            var appendRequest = service.Spreadsheets.Values.Append(append, spreadsheetId, "Commanders!A:D");
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
        }
    }

    public static void LogStationMetadata(string stationName, string systemName, string stationType, string commanderName)
    {
        var values = new List<IList<object>> {
        new List<object> {
            stationName,
            systemName,
            stationType,
            commanderName,
            DateTime.UtcNow.ToString("s") // Timestamp in UTC
        }
    };

        var valueRange = new ValueRange { Values = values };

        var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, "Stations!A:E");
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        appendRequest.Execute();
    }

    public static List<string> GetStationsInSystem(string systemName)
    {
        var request = service.Spreadsheets.Values.Get(spreadsheetId, "Stations!A2:B");
        var result = request.Execute();

        return result.Values?
            .Where(row => row.Count >= 2 && row[1].ToString() == systemName)
            .Select(row => row[0].ToString())
            .ToList() ?? new List<string>();
    }
    public static List<string> GetAllSystems()
    {
        var request = service.Spreadsheets.Values.Get(spreadsheetId, "Stations!A2:B");
        var result = request.Execute();

        return result.Values?
            .Where(row => row.Count > 1 && !string.IsNullOrWhiteSpace(row[1]?.ToString()))
            .Select(row => row[1].ToString().Trim())
            .Distinct()
            .OrderBy(name => name)
            .ToList() ?? new List<string>();
    }

    public static void LogCargoClaim(string commander, string squadron, string material, int amount, string system, string station)
    {
        string timestamp = DateTime.UtcNow.ToString("s");
        string status = "In Transit";

        var row = new List<object> { commander, squadron, material, amount, system, station, timestamp, status };
        var valueRange = new ValueRange
        {
            Values = new List<IList<object>> { row }
        };

        var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, "InTransit!A:H");
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        Console.WriteLine($"📤 Sending claim to sheet: {string.Join(", ", row)}");
        appendRequest.Execute();
    }
    public static void MarkAsDelivered(string commander, string material, string system, string station)
    {
        var range = "InTransit!A2:I"; // Skip header
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();
        var rows = response.Values;

        if (rows == null || rows.Count == 0) return;

        int rowIndex = 2; // Start at 2 because A1 is headers

        foreach (var row in rows)
        {
            // Match only if still "In Transit"
            if (row.Count >= 8 &&
                (string)row[0] == commander &&
                (string)row[2] == material &&
                (string)row[4] == system &&
                (string)row[5] == station &&
                (string)row[7] == "In Transit")
            {
                string deliveredTime = DateTime.UtcNow.ToString("s");

                // Update status + delivered timestamp
                var updateRange = $"InTransit!H{rowIndex}:I{rowIndex}";
                var valueRange = new ValueRange
                {
                    Values = new List<IList<object>>
                {
                    new List<object> { "Delivered", deliveredTime }
                }
                };

                var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, updateRange);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                updateRequest.Execute();
                break;
            }

            rowIndex++;
        }
    }
    
    public static void AddToCommanderTotal(string commander, string material, int amount)
    {
        // TODO: Update a summary sheet of totals per commander
        Console.WriteLine($"📊 {commander} total for {material} increased by {amount}");
    }
    public static List<(string material, string commander)> GetInTransitClaims(string system, string station)
    {
        var result = new List<(string, string)>();

        var range = "InTransit!A2:H";
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();

        foreach (var row in response.Values)
        {
            if (row.Count < 8) continue;

            string commander = row[0].ToString();
            string material = row[2].ToString();
            string sys = row[4].ToString();
            string sta = row[5].ToString();
            string status = row[7].ToString();

            if (sys == system && sta == station && status == "In Transit")
            {
                result.Add((material, commander));
            }
        }

        return result;
    }
    public static void UpdateCommanderDelivery(string commander, string material, int amount)
    {
        string range = "Commanders!A2:Z"; // Expand to cover all potential material columns
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();
        var rows = response.Values ?? new List<IList<object>>();

        int commanderRow = -1;
        int totalColIndex = 3; // "TotalTransferred" is at column D (0-based index 3)
        int materialColIndex = -1;

        // First row is header: find column index for the material
        var headersRequest = service.Spreadsheets.Values.Get(spreadsheetId, "Commanders!A1:Z1");
        var headersResponse = headersRequest.Execute();
        var headers = headersResponse.Values?.FirstOrDefault() ?? new List<object>();

        for (int i = 0; i < headers.Count; i++)
        {
            if (headers[i].ToString().Equals(material, StringComparison.OrdinalIgnoreCase))
            {
                materialColIndex = i;
                break;
            }
        }
        // If material column doesn't exist, add it
        if (materialColIndex == -1)
        {
            materialColIndex = headers.Count;
            var headerUpdate = new ValueRange
            {
                Values = new List<IList<object>> { new List<object> { material } }
            };
            var headerRange = $"Commanders!{GetColumnLetter(materialColIndex + 1)}1";
            var updateHeader = service.Spreadsheets.Values.Update(headerUpdate, spreadsheetId, headerRange);
            updateHeader.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            updateHeader.Execute();
        }

        if (commanderRow == -1)
            return; // Should never happen unless LogCommander() failed

        // Parse and update TotalTransferred
        int existingTotal = TryParseCell(rows[commanderRow - 2], totalColIndex);
        int newTotal = existingTotal + amount;
        UpdateCell(commanderRow, totalColIndex + 1, newTotal.ToString());

        // Parse and update per-material
        int existingMat = TryParseCell(rows[commanderRow - 2], materialColIndex);
        int newMat = existingMat + amount;
        UpdateCell(commanderRow, materialColIndex + 1, newMat.ToString());
    }

    private static int TryParseCell(IList<object> row, int index)
    {
        if (index >= row.Count) return 0;
        return int.TryParse(row[index]?.ToString(), out int val) ? val : 0;
    }

    private static void UpdateCell(int row, int col, string value)
    {
        var range = $"Commanders!{GetColumnLetter(col)}{row}";
        var update = new ValueRange
        {
            Values = new List<IList<object>> { new List<object> { value } }
        };

        var updateRequest = service.Spreadsheets.Values.Update(update, spreadsheetId, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        updateRequest.Execute();
    }

    private static string GetColumnLetter(int col)
    {
        string colLetter = "";
        while (col > 0)
        {
            int mod = (col - 1) % 26;
            colLetter = (char)('A' + mod) + colLetter;
            col = (col - mod) / 26;
        }
        return colLetter;
    }


    public static List<string> GetAllDeliveryCommanders(string material, string system, string station)
    {
        var result = new List<string>();

        var range = "InTransit!A2:H"; // adjust range if needed
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();

        foreach (var row in response.Values)
        {
            if (row.Count < 8) continue;

            string status = row[7].ToString();
            if (status != "Delivered") continue;

            if (row[2].ToString() == material &&
                row[4].ToString() == system &&
                row[5].ToString() == station)
            {
                result.Add(row[0].ToString());
            }
        }

        return result.Distinct().ToList();
    }
    public static void DeleteStation(string system, string station)
    {
        var service = GoogleSheetsHelper.service;

        // Step 1: Delete from Requirements
        var range = "Requirements!A2:H";
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();
        var rows = response.Values;

        List<int> rowsToClear = new List<int>();

        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            if (row.Count < 3) continue;

            string rowSystem = row[0].ToString().Trim();
            string rowStation = row[1].ToString().Trim();

            if (rowSystem == system && rowStation == station)
                rowsToClear.Add(i + 2); // +2 for 1-based index + header
        }

        foreach (int row in rowsToClear)
        {
            var clearRequest = new ClearValuesRequest();
            service.Spreadsheets.Values.Clear(clearRequest, spreadsheetId, $"Requirements!A{row}:H{row}").Execute();
        }

        Console.WriteLine($"✅ Deleted {rowsToClear.Count} row(s) from Requirements");

        // ✅ Step 2: Delete from Stations tab
        var stationRange = "Stations!A2:E"; // Adjust range if you have more columns
        var stationRequest = service.Spreadsheets.Values.Get(spreadsheetId, stationRange);
        var stationResponse = stationRequest.Execute();
        var stationRows = stationResponse.Values;

        List<int> stationRowsToClear = new List<int>();

        for (int i = 0; i < stationRows.Count; i++)
        {
            var row = stationRows[i];
            if (row.Count < 2) continue;

            string rowSystem = row[1].ToString().Trim();  // Column B = System
            string rowStation = row[0].ToString().Trim(); // Column A = Station

            if (rowSystem == system && rowStation == station)
            {
                stationRowsToClear.Add(i + 2); // +2 accounts for header row (starts at A2)
            }
        }

        // Actually delete those rows from Stations tab
        foreach (int rowIndex in stationRowsToClear)
        {
            var clearRequest = new ClearValuesRequest();
            service.Spreadsheets.Values.Clear(clearRequest, spreadsheetId, $"Stations!A{rowIndex}:E{rowIndex}").Execute();
        }
    }


    public static void UpdateStationDelivery(string material, string system, string station, int amount)
    {
        var range = "Requirements!A2:H"; // adjust as needed
        var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
        var response = request.Execute();
        var rows = response.Values;

        if (rows == null) return;

        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            if (row.Count < 8) continue;

            string rowSystem = row[0].ToString();
            string rowStation = row[1].ToString();
            string rowMaterial = row[2].ToString();

            if (rowSystem == system && rowStation == station && rowMaterial == material)
            {
                // Parse current Delivered + Remaining
                int delivered = int.TryParse(row[4].ToString(), out int d) ? d : 0;
                int remaining = int.TryParse(row[5].ToString(), out int r) ? r : 0;

                delivered += amount;
                remaining = Math.Max(0, remaining - amount);

                // Update Delivered and Remaining
                var update = new ValueRange
                {
                    Values = new List<IList<object>>
                {
                    new List<object> { delivered }
                }
                };
                var updateRequest1 = service.Spreadsheets.Values.Update(update, spreadsheetId, $"Requirements!E{i + 2}");
                updateRequest1.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                updateRequest1.Execute();

                update.Values = new List<IList<object>> { new List<object> { remaining } };
                var updateRequest2 = service.Spreadsheets.Values.Update(update, spreadsheetId, $"Requirements!F{i + 2}");
                updateRequest2.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                updateRequest2.Execute();

                break;
            }
        }
    }

}