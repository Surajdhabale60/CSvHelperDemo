﻿using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CSVHelperProject
{
    public class CSVHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\suraj\source\repos\217 .Net\CSVHelperDemo\CSVHelper\CSVHelper\Address.csv";
            string exportFilePath = @"C:\Users\suraj\source\repos\217 .Net\CSVHelperDemo\CSVHelper\CSVHelper\Export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.name);
                    Console.WriteLine("\t" + addressData.email);
                    Console.WriteLine("\t" + addressData.phone);
                    Console.WriteLine("\t" + addressData.country);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n************** Now reading from csv file and write to csv file **************");
                using var writer = new StreamWriter(exportFilePath);
                using var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture);
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
