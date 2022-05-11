

namespace Assignment_MVC.Models
{
    public class FeverCheckModel
    {
        public FeverCheckModel()
        {
            this.Fever = false;
            this.Hypothermia = false;
        }

        public enum Scale { Celcius, Fahrenheit }

        public Scale TempScale { get; set; }

        public decimal Temperature { get; set; }
        public bool Fever { get; set; }
        public bool Hypothermia { get; set; }

        public void GetFever()
        {
            if (this.Temperature > (decimal)(this.TempScale==Scale.Celcius?37.8:100.4)) this.Fever = true;
            else this.Fever = false;

            if (this.Temperature < (decimal)(this.TempScale == Scale.Celcius ? 35 : 95)) this.Hypothermia = true;
            else this.Hypothermia = false;
        }
    }
}
