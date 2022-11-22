using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;


namespace MiniValuationSystem
{
    public interface ICsvReader<T>
    {
        List<T> ReadCsv(string location);
    }
    public interface ICsvWriter<T>
    {
        public void WriteCsv(string location, List<T> T);
    }

    public class ReadFxForwardCsv : ICsvReader<FXForward>
    {
        public List<FXForward> ReadCsv(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<FXForwardMap>();
                    var records = csv.GetRecords<FXForward>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public class ReadFXOptionCsv : ICsvReader<FXOption>
    {
        public List<FXOption> ReadCsv(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<FXOptionMap>();
                    var records = csv.GetRecords<FXOption>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public class ReadRatesCsv : ICsvReader<Rates>
    {
        public List<Rates> ReadCsv(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<RatesMap>();
                    var records = csv.GetRecords<Rates>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public class ReadEquitiesCsv : ICsvReader<Equities>
    {
        public List<Equities> ReadCsv(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<EquitiesMap>();
                    var records = csv.GetRecords<Equities>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public class ReadMarketCsv : ICsvReader<Market>
    {
        public List<Market> ReadCsv(string location)
        {
            try
            {
                using (var reader = new StreamReader(location))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MarketMap>();
                    var records = csv.GetRecords<Market>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
    public class WriteToCsv : ICsvWriter<Result>
    {
        public void WriteCsv(string location, List<Result> resultData)
        {
            using (StreamWriter sw = new StreamWriter(location, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<Result>();
                cw.NextRecord();
                foreach (Result stu in resultData)
                {
                    cw.WriteRecord<Result>(stu);
                    cw.NextRecord();
                }
            }
        }
    }
}
