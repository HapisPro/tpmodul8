using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300069
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        string path = Path.GetFullPath("../../../../datas/covid_config.json");

        public CovidConfig()
        {
            this.satuan_suhu = "celcius";
            this.batas_hari_demam = 14;
            this.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            this.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public CovidConfig ReadConfigFile()
        {
            if (!File.Exists(path))
            {
                CovidConfig defaultConfig = new CovidConfig();
                WriteNewConfigFile(defaultConfig);
                return defaultConfig;
            }

            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CovidConfig>(jsonString);
        }

        public void WriteNewConfigFile(CovidConfig config)
        {
            string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        public void UbahSatuan()
        {
            satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            WriteNewConfigFile(this);
        }
    }
}
