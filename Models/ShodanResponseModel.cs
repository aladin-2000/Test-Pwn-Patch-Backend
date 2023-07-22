namespace test_Pwn_Pach.Models
{
    public class ShodanResponseModel
    {
        public string ip_str { get; set; }
        public string isp { get; set; }
        public string os { get; set; }
        public List<int> ports { get; set; }
        public string country_name { get; set; }
        public string city { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<string> hostnames { get; set; }
        public string organization { get; set; }
        public string region_code { get; set; }
        public string area_code { get; set; }
        public string postal_code { get; set; }
    }
}
