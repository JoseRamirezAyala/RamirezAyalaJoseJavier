using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PullToRefresh11
{
    public sealed class CitiesManager 
    {
        //http://csharpindepth.com/Articles/General/Singleton.aspx
        #region Singleton
        static readonly Lazy<CitiesManager> lazy =
            new Lazy<CitiesManager>(() => new CitiesManager());

        public static CitiesManager SharedInstance { get => lazy.Value; }
        #endregion
        #region Constructors
        CitiesManager()
        {
            httpClient = new HttpClient();
        }
        #endregion
        #region Events
        public event EventHandler<CitiesEventArgs> CitiesFetched;
        public event EventHandler<EventArgs> FetchCitiesFailed;
        public event EventHandler<ExceptionCitiesArgs> ExceptionCitiesA;
        #endregion
        #region Notification

        #endregion
        #region ClassVariables
        HttpClient httpClient;
        Dictionary<string, List<string>> cities;
        #endregion
        #region Public Functionality
        public Dictionary<string, List<string>> GetDefaultCities()
        {
            var citiesJson = File.ReadAllText("citites-incomplete.json");
            //Vamos a parsear el Json, usando Json.net
            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);

        }
        public void FetchCities()
        {
            Task.Factory.StartNew(FetchCitiesAsync);
            //Metodo sincrono con metodos asyncronos dentro, en realidad es un metodo asyncrono.
            async Task FetchCitiesAsync()
            {
                try
                {
                    var citiesJson = await httpClient.GetStringAsync("https://dl.dropbox.com/s/0adq8yw6vd5r6bj/cities.json?dl=0");
                    cities = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(citiesJson);
                    //Avisar al controller que ya esta disponible eush eush los datos eush
                    //1. A traves de eventos (Event/ Objecti-c delegates)
                    //2. A traves de notificaciones
                    //3. A traves de Segue (Solo cuando estas debtri de un ViewController);


                    //Evento
                    if(CitiesFetched == null)
                    {
                        return;   
                    }
                    var e = new CitiesEventArgs(cities);
                    CitiesFetched(this, e);


                }
                catch (Exception ex)
                {
                    //Notificarle al contoller de que algo fallo
                    //1. A traves de eventos (Event/ Objecti-c delegates)
                    //2. A traves de notificaciones
                    //3. A traves de Segue (Solo cuando estas debtri de un ViewController);
                    if(FetchCitiesFailed == null)
                    {
                        return;
                    }
                    ExceptionCitiesA(this, new ExceptionCitiesArgs(ex));
                }
            }
        }
        #endregion



    }
    public class CitiesEventArgs : EventArgs
    {
        public Dictionary<string, List<string>> Cities { get; private set; }
        public CitiesEventArgs(Dictionary<string, List<string>> cities)
        {
            Cities = cities;
        }
    }
    public class ExceptionCitiesArgs : EventArgs
    {
        public Exception ex { get; private set; }
        public ExceptionCitiesArgs(Exception Ex)
        {
            ex = Ex;
        }
    }
}
