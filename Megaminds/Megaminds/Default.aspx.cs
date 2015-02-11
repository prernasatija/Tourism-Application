using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;

namespace Megaminds
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                //Response.Write(HttpContext.Current.Application.Contents["test"]);
                string[] ContextKeys = HttpContext.Current.Application.AllKeys;
                statusbuttonclick.Text = "";
                for (int i = 0; i < ContextKeys.Length; i++)
                {
                    string ContextKey = ContextKeys[i];
                    if (ContextKey == "test")
                        statusbuttonclick.Text = HttpContext.Current.Application.Contents["test"].ToString();
                        HttpContext.Current.Application.Remove("test");
                }
                }catch(Exception) {
                }
            current.Text = "Hello " + LoginPage.Userv + " !!";
            string role = LoginPage.Rolev;
            if (role == null)
            {
                mainpanel.Visible = false;
                login.Visible = true;
                register.Visible = true;
            }
            else
            {
                logout.Visible = true;
                mainpanel.Visible = true;
                login.Visible = false;
                register.Visible = false;

            }
            hideAllPanels();
            colorButtons();
        }

        protected void news_Click(object sender, EventArgs e)
        {
            statusnews.Text = "";
            statusweather.Text = "";
            statusbuttonclick.Text = "";
            newspanel.Visible = true;
            news.BackColor = System.Drawing.Color.Gray;

            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
                //statusnews.Text = "Please Enter a city name first !!!";
                //return;
            }
            Geocoder.SearchClient geo = new Geocoder.SearchClient();
            string geocode = geo.GetGeocodeFromCityName(cityname.Text);
            string latitude = geocode.Split(',')[0];
            string longitude = geocode.Split(',')[1];

            getSunTiming(latitude, longitude);
            getTimezone(latitude, longitude);

            string zipcode = geo.GetZipCodeFromGeocode(latitude, longitude);

            ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
            String returnedNews = sc.NewsFocus(cityname.Text);
            String[] News = returnedNews.Split('\n');

            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            Label l1 = new Label();
            l1.Text = "Current NEWS";
            cell.Controls.Add(l1);
            row.Cells.Add(cell);

            newstable.Rows.Add(row);

            for (int i = 0; i < News.Length - 1; i++)
            {
                string[] temp = News[i].Split('|');
                row = new TableRow();
                cell = new TableCell();

                HyperLink h = new HyperLink();
                h.ID = "NEWS" + i;
                h.Text = temp[0];
                h.NavigateUrl = temp[1];
                cell.Controls.Add(h);
                row.Cells.Add(cell);
                newstable.Rows.Add(row);

            }

            String returnedWeather = sc.Weather5day(zipcode);
            if (returnedWeather.Equals("Please enter a valid Zip code") || returnedWeather.Equals("No data available right now"))
            {
                //statusweather.Text = "Please Enter a Valid City for Weather";
                //return;
                throw new InvalidOperationException("Please Enter a Valid City for Weather");
            }
            else
            {

                statusweather.Text = "Weather Forcast";
                String[] ret = returnedWeather.Split('\n');
                int numLines = ret.Length;

                row = new TableRow();
                cell = new TableCell();
                l1 = new Label();
                l1.Text = "DAY/TIME";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);


                cell = new TableCell();
                l1 = new Label();
                l1.Text = "WEATHER";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);


                weathertable.Rows.Add(row);

                for (int i = 0; i < ret.Length - 1; i++)
                {
                    string[] temp = ret[i].Split(':');

                    row = new TableRow();
                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = temp[0];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);


                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = temp[1];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    weathertable.Rows.Add(row);

                }
            }
        }

        private void getSunTiming(string latitude, string longitude)
        {
            string url = "http://webstrar39.fulton.asu.edu/Page9/SunTime.svc/getSunriseSunsetTimes?";
            url += "latitude=" + latitude + "&longitude=" + longitude;
            WebClient webClient = new WebClient();
            string data = webClient.DownloadString(url);
            string[] times = data.Split('|');
            if (times.Length == 2)
            {
                sunrise.Text = "Sunrise at " + times[0] + " hours";
                sunset.Text = "Sunset at " + times[1] + " hours";
            }
            else
            {
                sunrise.Text = "Unable to recover Sunrise timings.";
                sunset.Text = "Unable to recover Sunset timings.";
            }
        }

        private void getTimezone(string latitude, string longitude)
        {
            string url = "http://webstrar39.fulton.asu.edu/page3/Service1.svc/getTimeZone?latitude=";
            url += latitude + "&longitude=" + longitude;
            WebClient web = new WebClient();
            string result = web.DownloadString(url);
            if (!string.IsNullOrEmpty(result))
            {
                string[] split = result.Split('|');
                timezone.Text = "Time Zone " + split[0] + " (" + split[1] + ")";
            }
        }

        protected void events_Click(object sender, EventArgs e)
        {
            
            statusbuttonclick.Text = "";
            statusattraction.Text = "";
            statusevent.Text = "";
            eventspanel.Visible = true;
            events.BackColor = System.Drawing.Color.Gray;
            if (cityname.Text == "")
            {
                //statusattraction.Text = "Please Enter a city name first !!!";
                //return;
                throw new InvalidOperationException("Please Enter a city name first !!!");
                
            }
            Geocoder.SearchClient geo = new Geocoder.SearchClient();
            string geocode = geo.GetGeocodeFromCityName(cityname.Text);
            string latitude = geocode.Split(',')[0];
            string longitude = geocode.Split(',')[1];

            //string zipcode = geo.GetZipCodeFromGeocode(latitude, longitude);

            ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
            string[] nearestTouristAttractions = sc.getTouristAttraction(latitude, longitude);
            if (nearestTouristAttractions.Length == 0)
            {
                throw new InvalidOperationException("Please enter a correct city name !!!");
                //statusattraction.Text = "Please enter a correct city name !!!";
                //return;
            }
            else if (nearestTouristAttractions[0].Equals("error"))
            {
                throw new InvalidOperationException("Error !!!");
                //statusattraction.Text = "Error !!!";
                //return;
            }
            else
            {
                statusattraction.Text = "Nearest Tourist Attractions";
                TableRow row = new TableRow();


                TableCell cell = new TableCell();
                Label l1 = new Label();
                l1.Text = "NAME";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "ADDRESS";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "CATEGORY";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "RATING";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                attractionstable.Rows.Add(row);

                for (int i = 0; i < nearestTouristAttractions.Length; i++)
                {
                    string[] res = nearestTouristAttractions[i].Split('|');

                    row = new TableRow();

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[0];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[1];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[2];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[3];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    attractionstable.Rows.Add(row);

                }

            }

            string[] eventresult = sc.getUpcomingEvents(latitude, longitude);
            if (eventresult == null)
            {
                throw new InvalidOperationException("Error !!!");
                //statusevent.Text = "Error !!!";
            }
            else
            {
                statusevent.Text = "Near by Events";
                TableRow row = new TableRow();


                TableCell cell = new TableCell();
                Label l1 = new Label();
                l1.Text = "EVENT NAME";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "START";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "END";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "ADDRESS";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                cell = new TableCell();
                l1 = new Label();
                l1.Text = "DISTANCE(Miles)";
                cell.Controls.Add(l1);
                row.Cells.Add(cell);

                eventstable.Rows.Add(row);

                for (int i = 0; i < eventresult.Length; i++)
                {
                    string[] res = eventresult[i].Split('|');

                    row = new TableRow();

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[0];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[1];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[2];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[3];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    l1 = new Label();
                    l1.Text = res[4];
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    eventstable.Rows.Add(row);

                }
            }
        }

        protected void emergency_Click(object sender, EventArgs e)
        {
            

            statusbuttonclick.Text = "";
            hideAllPanels();
            emergency.BackColor = System.Drawing.Color.Gray;
            emergencypanel.Visible = true;
            emergencyResults.Text = "";
            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
                //statusnews.Text = "Please Enter a city name first !!!";
                //return;
            }
        }

        protected void emergencyButton_Click(object sender, EventArgs e)
        {
            statusbuttonclick.Text = "";
            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
                //statusnews.Text = "Please Enter a city name first !!!";
                //return;
            }
            emergencypanel.Visible = true;
            Geocoder.SearchClient service = new Geocoder.SearchClient();
            string code = service.GetGeocodeFromCityName(cityname.Text);
            string[] codes = code.Split(',');
            string response = service.GetEmergencyServices(codes[0], codes[1], emergencyType.SelectedItem.Value);
            XmlDocument result = new XmlDocument();
            result.LoadXml(response);
            string output = "";
            XmlNodeList services = result.SelectNodes("Services/Service");
            foreach (XmlNode srv in services)
            {
                string name = srv["Name"].InnerText;
                string address = srv["Address"].InnerText;
                output += "&nbsp;+&nbsp;" + name + ",&nbsp;" + address;
                output += "<br /><br />";
            }
            emergencyResults.Text = output;
        }

        protected void nearest_Click(object sender, EventArgs e)
        {
            statusbuttonclick.Text = "";
            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
            }
            hideAllPanels();
            nearest.BackColor = System.Drawing.Color.Gray;
            nearestpanel.Visible = true;
            searchResults.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            statusbuttonclick.Text = "";
            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
            }
            nearestpanel.Visible = true;
            Geocoder.SearchClient service = new Geocoder.SearchClient();
            string code = service.GetGeocodeFromCityName(cityname.Text);
            string[] codes = code.Split(',');
            string query = storeType.SelectedItem.Value;
            if(query == "food" || query == "drinks" || query == "coffee" || query == "arts" || query == "outdoors")
            {
                string response = service.SearchFor(cityname.Text, query);
                XmlDocument result = new XmlDocument();
                result.LoadXml(response);
                string output = "";
                XmlNodeList venues = result.SelectNodes("results/venue");
                foreach (XmlNode venue in venues)
                {
                    string name = venue["name"].InnerText;
                    string address = venue["address"].InnerText;
                    string phone = venue["phone"].InnerText;
                    string url = venue["url"].InnerText;
                    string rating = venue["rating"].InnerText;
                    string isOpen = venue["isOpen"].InnerText;
                    output += name + "<br />";
                    output += "  - Address: " + address;
                    output += "  - Phone: " + phone + "<br />";
                    output += "  - URL: " + url + "<br />";
                    output += "  - Rating: " + rating + "<br />";
                    output += "  - Open: " + isOpen + "<br />";
                    output += "<br />";
                }
                searchResults.Text = output;
            }
            else if (query == "gas_station" || query == "train_station" || query == "subway_station")
            {
                Search.ServiceClient searchService = new Search.ServiceClient();
                string xmlResponse = searchService.getStationInfo(codes[0], codes[1], query);
                XmlDocument result = new XmlDocument();
                result.LoadXml(xmlResponse);
                string queryResults = "";
                XmlNodeList stationList = result.SelectNodes("results/station");
                foreach (XmlNode station in stationList)
                {
                    string name = station["name"].InnerText;
                    string address = station["vicinity"].InnerText;
                    queryResults += name + "<br />" + "&nbsp;&nbsp;-&nbsp;Address: " + address + "<br />";
                }
                searchResults.Text = queryResults;
            }
            else if (query == "beauty_salon" || query == "spa" || query == "hair_care")
            {
                Search.ServiceClient searchService = new Search.ServiceClient();
                string res = searchService.findBeautySalons(codes[0], codes[1], query);
                string[] places = res.Split('+');
                string result = "";
                foreach (string place in places)
                {
                    if (!string.IsNullOrEmpty(place))
                    {
                        string[] parameters = place.Split('|');
                        result += parameters[0] + "<br />";
                        result += "  - Address: " + parameters[1] + "<br />";
                        if (parameters.Length == 3)
                            result += "  - Open: " + parameters[2] + "<br />";
                        result += "<br />";
                    }

                }
                searchResults.Text = result;
            }
            else if (query == "atm" || query == "bank")
            {
                ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
                String[] returnedbankatm = sc.getNearestBankAtm(codes[0], codes[1], query);
                if (returnedbankatm == null)
                {
                    throw new InvalidOperationException("Server Error !!!");
                }
                else
                {
                    TableRow row = new TableRow();


                    TableCell cell = new TableCell();
                    Label l1 = new Label();
                    l1.Text = "NAME";
                    cell.Controls.Add(l1);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    Label l2 = new Label();
                    l2.Text = "ADDRESS";
                    cell.Controls.Add(l2);
                    row.Cells.Add(cell);

                    bankatmtable.Rows.Add(row);

                    for (int i = 0; i < returnedbankatm.Length; i++)
                    {
                        string[] res = returnedbankatm[i].Split('|');
                        row = new TableRow();


                        cell = new TableCell();
                        l1 = new Label();
                        l1.Text = res[0];
                        cell.Controls.Add(l1);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        l2 = new Label();
                        l2.Text = res[1];
                        cell.Controls.Add(l2);
                        row.Cells.Add(cell);

                        bankatmtable.Rows.Add(row);

                    }   
                }
            }
            else
            {
                string zipcode = service.GetZipCodeFromGeocode(codes[0], codes[1]);
                searchResults.Text = "<b>Address: </b>" + service.GetNearestStore(zipcode, storeName.Text);
            }
        }

        protected void cities_Click(object sender, EventArgs e)
        {
            statusbuttonclick.Text = "";
            if (cityname.Text == "")
            {
                throw new InvalidOperationException("Please Enter a city name first !!!");
            }
            else
            {
                citiespanel.Visible = true;
                cities.BackColor = System.Drawing.Color.Gray;
                Geocoder.SearchClient geocode = new Geocoder.SearchClient();
                string code = geocode.GetGeocodeFromCityName(cityname.Text);
                string[] codes = code.Split(',');
                Search.ServiceClient service = new Search.ServiceClient();
                String res = service.getNearByCities(codes[0], codes[1]);
                XmlDocument result = new XmlDocument();
                try
                {
                    result.LoadXml(res);
                }
                catch (XmlException exp)
                {
                    throw new InvalidOperationException("Sorry, No results found!!");
                }
                string output = "";
                XmlNodeList citiesNode = result.SelectNodes("Cities/City");
                Boolean first = true;
                foreach (XmlNode city in citiesNode)
                {
                    string cityName = city["CityName"].InnerText;
                    string state = city["State"].InnerText;
                    string cityLatitude = city["Latitude"].InnerText;
                    string cityLongitude = city["Longitude"].InnerText;
                    string zipCode = city["ZipCode"].InnerText;
                    string distance = city["Distance"].InnerText;
                    if (first)
                    {
                        output += "<b>Current City:</b><br />";
                        output += cityName + ", " + state + "<br />";
                        output += "  - " + "Zip Code: " + zipCode + "<br />";
                        output += "  - " + "Geocodes: (" + cityLatitude + ", " + cityLongitude + " )<br />";
                        output += "<br /><b>Nearby Cities:</b><br />";
                        first = false;
                    }
                    else
                    {
                        output += cityName + ", " + state + "<br />";
                        output += "  - " + "Distance: " + distance + "<br />";
                        output += "  - " + "Zip Code: " + zipCode + "<br />";
                        output += "  - " + "Geocodes: (" + cityLatitude + ", " + cityLongitude + " )<br />";
                        output += "<br />";
                    }
                }
                if (!first)
                    citiesResults.Text = output;
                else
                    throw new InvalidOperationException("Something is not right.");
            }
        }

        private void hideAllPanels()
        {
            newspanel.Visible = false;
            eventspanel.Visible = false;
            nearestpanel.Visible = false;
            citiespanel.Visible = false;
            emergencypanel.Visible = false;
            
        }

        private void colorButtons()
        {
            news.BackColor = System.Drawing.Color.LightGray;
            events.BackColor = System.Drawing.Color.LightGray;
            nearest.BackColor = System.Drawing.Color.LightGray;
            cities.BackColor = System.Drawing.Color.LightGray;
            emergency.BackColor = System.Drawing.Color.LightGray;
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            LoginPage.Userv = null;
            LoginPage.Rolev = null;
            login.Visible = true;
            register.Visible = true;
            current.Text = "Hello " + (string)Session["user"] + "!!";
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}