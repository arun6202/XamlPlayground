using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;
using XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.Helpers;



[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground
{
    public partial class App : Application
    {
        private const string UriString = "http://localhost:6202/api/XamlPlaygroundSync";
        internal static ContentPage ContentPageSync;
        static XamlPayload XamlPayload = new XamlPayload();

        public App()
        {
            InitializeComponent();

            CreateBogusResources();

            var playground = new Playground();

            MainPage = playground;

            ContentPageSync = playground;

            IntializeXamlSync();

        }

        private static void IntializeXamlSync()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
           {
               Task.Factory.StartNew(async () => await RunXAMLChanges());
               return true;
           });
        }

        private static async Task RunXAMLChanges()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(UriString);

                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var message = JsonConvert.DeserializeObject<XamlPayload>(responseBody, JsonSerializerSettingsConverter.Settings);

                    if (!string.IsNullOrEmpty(message.XAML) || !string.IsNullOrEmpty(message.PreserveXML))
                    {

                        if (XamlPayload.XAML == null)
                        {
                            XamlPayload = message;
                            await LiveXamlHelper.PreviewXaml(message.XAML, ContentPageSync);
                        }

                        bool areXamlSame = XamlPayload.CompareTo(message) == 0;
                        if (!areXamlSame)
                        {
                            XamlPayload = message;
                            await LiveXamlHelper.PreviewXaml(message.XAML, ContentPageSync);
                        }

                    }

                }

            }
        }

        protected override void OnStart()
        {

            // await IntializeXamlSync();
            //to do when signal r issue is solved please use that::
            //await XamlPlaygroundSyncConsume.Sync();
        }



        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void CreateBogusResources()
        {
            Resources["ZipCode"] = BogusGenerator.ZipCode().ToString();
            // Console.WriteLine("ZipCode:" + ZipCode).ToString();
            Resources["City"] = BogusGenerator.City().ToString();
            // Console.WriteLine("City:" + City).ToString();
            Resources["StreetAddress"] = BogusGenerator.StreetAddress(false).ToString();
            // Console.WriteLine("StreetAddress:" + StreetAddress).ToString();
            Resources["CityPrefix"] = BogusGenerator.CityPrefix().ToString();
            // Console.WriteLine("CityPrefix:" + CityPrefix).ToString();
            Resources["CitySuffix"] = BogusGenerator.CitySuffix().ToString();
            // Console.WriteLine("CitySuffix:" + CitySuffix).ToString();
            Resources["StreetName"] = BogusGenerator.StreetName().ToString();
            // Console.WriteLine("StreetName:" + StreetName).ToString();
            Resources["BuildingNumber"] = BogusGenerator.BuildingNumber().ToString();
            // Console.WriteLine("BuildingNumber:" + BuildingNumber).ToString();
            Resources["StreetSuffix"] = BogusGenerator.StreetSuffix().ToString();
            // Console.WriteLine("StreetSuffix:" + StreetSuffix).ToString();
            Resources["SecondaryAddress"] = BogusGenerator.SecondaryAddress().ToString();
            // Console.WriteLine("SecondaryAddress:" + SecondaryAddress).ToString();
            Resources["County"] = BogusGenerator.County().ToString();
            // Console.WriteLine("County:" + County).ToString();
            Resources["Country"] = BogusGenerator.Country().ToString();
            // Console.WriteLine("Country:" + Country).ToString();
            Resources["FullAddress"] = BogusGenerator.FullAddress().ToString();
            // Console.WriteLine("FullAddress:" + FullAddress).ToString();
            Resources["CountryCode"] = BogusGenerator.CountryCode("Alpha2").ToString();
            // Console.WriteLine("CountryCode:" + CountryCode).ToString();
            Resources["State"] = BogusGenerator.State().ToString();
            // Console.WriteLine("State:" + State).ToString();
            Resources["StateAbbr"] = BogusGenerator.StateAbbr().ToString();
            // Console.WriteLine("StateAbbr:" + StateAbbr).ToString();
            Resources["Latitude"] = BogusGenerator.Latitude(9, 9).ToString();
            // Console.WriteLine("Latitude:" + Latitude).ToString();
            Resources["Longitude"] = BogusGenerator.Longitude(5, 7).ToString();
            // Console.WriteLine("Longitude:" + Longitude).ToString();
            Resources["Direction"] = BogusGenerator.Direction(false).ToString();
            // Console.WriteLine("Direction:" + Direction).ToString();
            Resources["CardinalDirection"] = BogusGenerator.CardinalDirection(false).ToString();
            // Console.WriteLine("CardinalDirection:" + CardinalDirection).ToString();
            Resources["OrdinalDirection"] = BogusGenerator.OrdinalDirection(false).ToString();
            // Console.WriteLine("OrdinalDirection:" + OrdinalDirection).ToString();
            Resources["Department"] = BogusGenerator.Department(3, false).ToString();
            // Console.WriteLine("Department:" + Department).ToString();
            Resources["Price"] = BogusGenerator.Price(1, 1, 0002, "$").ToString();
            // Console.WriteLine("Price:" + Price).ToString();
            Resources["Categories"] = BogusGenerator.Categories(3).ToString();
            // Console.WriteLine("Categories:" + Categories).ToString();
            Resources["ProductName"] = BogusGenerator.ProductName().ToString();
            // Console.WriteLine("ProductName:" + ProductName).ToString();
            Resources["Color"] = BogusGenerator.Color().ToString();
            // Console.WriteLine("Color:" + Color).ToString();
            Resources["Product"] = BogusGenerator.Product().ToString();
            // Console.WriteLine("Product:" + Product).ToString();
            Resources["ProductAdjective"] = BogusGenerator.ProductAdjective().ToString();
            // Console.WriteLine("ProductAdjective:" + ProductAdjective).ToString();
            Resources["ProductMaterial"] = BogusGenerator.ProductMaterial().ToString();
            // Console.WriteLine("ProductMaterial:" + ProductMaterial).ToString();
            Resources["CompanySuffix"] = BogusGenerator.CompanySuffix().ToString();
            // Console.WriteLine("CompanySuffix:" + CompanySuffix).ToString();
            Resources["CompanyName"] = BogusGenerator.CompanyName(2).ToString();
            // Console.WriteLine("CompanyName:" + CompanyName).ToString();
            Resources["CompanyName"] = BogusGenerator.CompanyName("{ { name.lastName} }{ { company.companySuffix} }").ToString();
            // Console.WriteLine("CompanyName:" + CompanyName).ToString();
            Resources["CatchPhrase"] = BogusGenerator.CatchPhrase().ToString();
            // Console.WriteLine("CatchPhrase:" + CatchPhrase).ToString();
            Resources["Bs"] = BogusGenerator.Bs().ToString();
            // Console.WriteLine("Bs:" + Bs).ToString();
            Resources["Column"] = BogusGenerator.Column().ToString();
            // Console.WriteLine("Column:" + Column).ToString();
            Resources["Type"] = BogusGenerator.Type().ToString();
            // Console.WriteLine("Type:" + Type).ToString();
            Resources["Collation"] = BogusGenerator.Collation().ToString();
            // Console.WriteLine("Collation:" + Collation).ToString();
            Resources["Engine"] = BogusGenerator.Engine().ToString();
            // Console.WriteLine("Engine:" + Engine).ToString();
            Resources["Past"] = BogusGenerator.Past(1, DateTime.Now).ToString();
            // Console.WriteLine("Past:" + Past).ToString();
            Resources["Soon"] = BogusGenerator.Soon(1).ToString();
            // Console.WriteLine("Soon:" + Soon).ToString();
            Resources["Future"] = BogusGenerator.Future(1, DateTime.Now).ToString();
            // Console.WriteLine("Future:" + Future).ToString();
            Resources["Between"] = BogusGenerator.Between(DateTime.Now.AddYears(-2), DateTime.Now).ToString();
            // Console.WriteLine("Between:" + Between).ToString();
            Resources["Recent"] = BogusGenerator.Recent(1).ToString();
            // Console.WriteLine("Recent:" + Recent).ToString();
            Resources["Timespan"] = BogusGenerator.Timespan(TimeSpan.FromSeconds(10)).ToString();
            // Console.WriteLine("Timespan:" + Timespan).ToString();
            Resources["Month"] = BogusGenerator.Month(false, false).ToString();
            // Console.WriteLine("Month:" + Month).ToString();
            Resources["Weekday"] = BogusGenerator.Weekday(false, false).ToString();
            // Console.WriteLine("Weekday:" + Weekday).ToString();
            Resources["Account"] = BogusGenerator.Account(8).ToString();
            // Console.WriteLine("Account:" + Account).ToString();
            Resources["AccountName"] = BogusGenerator.AccountName().ToString();
            // Console.WriteLine("AccountName:" + AccountName).ToString();
            Resources["Amount"] = BogusGenerator.Amount(01, 00, 02).ToString();
            // Console.WriteLine("Amount:" + Amount).ToString();
            Resources["TransactionType"] = BogusGenerator.TransactionType().ToString();
            // Console.WriteLine("TransactionType:" + TransactionType).ToString();
            Resources["Currency"] = BogusGenerator.Currency(false).ToString();
            // Console.WriteLine("Currency:" + Currency).ToString();
            Resources["CreditCardNumber"] = BogusGenerator.CreditCardNumber().ToString();
            // Console.WriteLine("CreditCardNumber:" + CreditCardNumber).ToString();
            Resources["CreditCardCvv"] = BogusGenerator.CreditCardCvv().ToString();
            // Console.WriteLine("CreditCardCvv:" + CreditCardCvv).ToString();
            Resources["BitcoinAddress"] = BogusGenerator.BitcoinAddress().ToString();
            // Console.WriteLine("BitcoinAddress:" + BitcoinAddress).ToString();
            Resources["EthereumAddress"] = BogusGenerator.EthereumAddress().ToString();
            // Console.WriteLine("EthereumAddress:" + EthereumAddress).ToString();
            Resources["RoutingNumber"] = BogusGenerator.RoutingNumber().ToString();
            // Console.WriteLine("RoutingNumber:" + RoutingNumber).ToString();
            Resources["Bic"] = BogusGenerator.Bic().ToString();
            // Console.WriteLine("Bic:" + Bic).ToString();
            Resources["Iban"] = BogusGenerator.Iban(false).ToString();
            // Console.WriteLine("Iban:" + Iban).ToString();
            Resources["Abbreviation"] = BogusGenerator.Abbreviation().ToString();
            // Console.WriteLine("Abbreviation:" + Abbreviation).ToString();
            Resources["Adjective"] = BogusGenerator.Adjective().ToString();
            // Console.WriteLine("Adjective:" + Adjective).ToString();
            Resources["Noun"] = BogusGenerator.Noun().ToString();
            // Console.WriteLine("Noun:" + Noun).ToString();
            Resources["Verb"] = BogusGenerator.Verb().ToString();
            // Console.WriteLine("Verb:" + Verb).ToString();
            Resources["IngVerb"] = BogusGenerator.IngVerb().ToString();
            // Console.WriteLine("IngVerb:" + IngVerb).ToString();
            Resources["Phrase"] = BogusGenerator.Phrase().ToString();
            // Console.WriteLine("Phrase:" + Phrase).ToString();
            Resources["Image"] = BogusGenerator.Image(64, 80, false, false).ToString();
            // Console.WriteLine("Image:" + Image).ToString();
            Resources["Abstract"] = BogusGenerator.Abstract(640, 480, false, false).ToString();
            // Console.WriteLine("Abstract:" + Abstract).ToString();
            Resources["Animals"] = BogusGenerator.Animals(640, 480, false, false).ToString();
            // Console.WriteLine("Animals:" + Animals).ToString();
            Resources["Business"] = BogusGenerator.Business(640, 480, false, false).ToString();
            // Console.WriteLine("Business:" + Business).ToString();
            Resources["Cats"] = BogusGenerator.Cats(640, 480, false, false).ToString();
            // Console.WriteLine("Cats:" + Cats).ToString();
            Resources["City"] = BogusGenerator.City(640, 480, false, false).ToString();
            // Console.WriteLine("City:" + City).ToString();
            Resources["Food"] = BogusGenerator.Food(640, 480, false, false).ToString();
            // Console.WriteLine("Food:" + Food).ToString();
            Resources["Nightlife"] = BogusGenerator.Nightlife(640, 480, false, false).ToString();
            // Console.WriteLine("Nightlife:" + Nightlife).ToString();
            Resources["Fashion"] = BogusGenerator.Fashion(640, 480, false, false).ToString();
            // Console.WriteLine("Fashion:" + Fashion).ToString();
            Resources["People"] = BogusGenerator.People(640, 480, false, false).ToString();
            // Console.WriteLine("People:" + People).ToString();
            Resources["Nature"] = BogusGenerator.Nature(640, 480, false, false).ToString();
            // Console.WriteLine("Nature:" + Nature).ToString();
            Resources["Sports"] = BogusGenerator.Sports(640, 480, false, false).ToString();
            // Console.WriteLine("Sports:" + Sports).ToString();
            Resources["Technics"] = BogusGenerator.Technics(640, 480, false, false).ToString();
            // Console.WriteLine("Technics:" + Technics).ToString();
            Resources["Transport"] = BogusGenerator.Transport(640, 480, false, false).ToString();
            // Console.WriteLine("Transport:" + Transport).ToString();
            Resources["DataUri"] = BogusGenerator.DataUri(640, 480).ToString();
            // Console.WriteLine("DataUri:" + DataUri).ToString();
            Resources["Avatar"] = BogusGenerator.Avatar().ToString();
            // Console.WriteLine("Avatar:" + Avatar).ToString();
            Resources["Email"] = BogusGenerator.Email("arun", "balakrish", "yahoo").ToString();
            // Console.WriteLine("Email:" + Email).ToString();
            Resources["ExampleEmail"] = BogusGenerator.ExampleEmail("arun", "balakrish").ToString();
            // Console.WriteLine("ExampleEmail:" + ExampleEmail).ToString();
            Resources["UserName"] = BogusGenerator.UserName("arun", "balakrish").ToString();
            // Console.WriteLine("UserName:" + UserName).ToString();
            Resources["DomainName"] = BogusGenerator.DomainName().ToString();
            // Console.WriteLine("DomainName:" + DomainName).ToString();
            Resources["DomainWord"] = BogusGenerator.DomainWord().ToString();
            // Console.WriteLine("DomainWord:" + DomainWord).ToString();
            Resources["DomainSuffix"] = BogusGenerator.DomainSuffix().ToString();
            // Console.WriteLine("DomainSuffix:" + DomainSuffix).ToString();
            Resources["Ip"] = BogusGenerator.Ip().ToString();
            // Console.WriteLine("Ip:" + Ip).ToString();
            Resources["Ipv6"] = BogusGenerator.Ipv6().ToString();
            // Console.WriteLine("Ipv6:" + Ipv6).ToString();
            Resources["UserAgent"] = BogusGenerator.UserAgent().ToString();
            // Console.WriteLine("UserAgent:" + UserAgent).ToString();
            Resources["Mac"] = BogusGenerator.Mac(":").ToString();
            // Console.WriteLine("Mac:" + Mac).ToString();
            Resources["Password"] = BogusGenerator.Password(10, false, "\\w", "").ToString();
            // Console.WriteLine("Password:" + Password).ToString();
            Resources["Protocol"] = BogusGenerator.Protocol().ToString();
            // Console.WriteLine("Protocol:" + Protocol).ToString();
            Resources["Url"] = BogusGenerator.Url().ToString();
            // Console.WriteLine("Url:" + Url).ToString();
            Resources["UrlWithPath"] = BogusGenerator.UrlWithPath("tcp", "kumar").ToString();
            // Console.WriteLine("UrlWithPath:" + UrlWithPath).ToString();
            Resources["Word"] = BogusGenerator.Word().ToString();
            // Console.WriteLine("Word:" + Word).ToString();
            Resources["Words"] = BogusGenerator.Words(3).ToString();
            // Console.WriteLine("Words:" + Words).ToString();
            Resources["Letter"] = BogusGenerator.Letter(1).ToString();
            // Console.WriteLine("Letter:" + Letter).ToString();
            Resources["Sentence"] = BogusGenerator.Sentence(8, 8).ToString();
            // Console.WriteLine("Sentence:" + Sentence).ToString();
            Resources["Sentences"] = BogusGenerator.Sentences(5, ":").ToString();
            // Console.WriteLine("Sentences:" + Sentences).ToString();
            Resources["Paragraph"] = BogusGenerator.Paragraph(3).ToString();
            // Console.WriteLine("Paragraph:" + Paragraph).ToString();
            Resources["Paragraphs"] = BogusGenerator.Paragraphs(3, "_").ToString();
            // Console.WriteLine("Paragraphs:" + Paragraphs).ToString();
            Resources["Paragraphs"] = BogusGenerator.Paragraphs(3, "_").ToString();
            // Console.WriteLine("Paragraphs:" + Paragraphs).ToString();
            Resources["Text"] = BogusGenerator.Text().ToString();
            // Console.WriteLine("Text:" + Text).ToString();
            Resources["Lines"] = BogusGenerator.Lines(3, "_").ToString();
            // Console.WriteLine("Lines:" + Lines).ToString();
            Resources["Slug"] = BogusGenerator.Slug(3).ToString();
            // Console.WriteLine("Slug:" + Slug).ToString();
            Resources["FirstName"] = BogusGenerator.FirstName("Male").ToString();
            // Console.WriteLine("FirstName:" + FirstName).ToString();
            Resources["LastName"] = BogusGenerator.LastName("Male").ToString();
            // Console.WriteLine("LastName:" + LastName).ToString();
            Resources["FullName"] = BogusGenerator.FullName("Male").ToString();
            // Console.WriteLine("FullName:" + FullName).ToString();
            Resources["Prefix"] = BogusGenerator.Prefix("Male").ToString();
            // Console.WriteLine("Prefix:" + Prefix).ToString();
            Resources["Suffix"] = BogusGenerator.Suffix().ToString();
            // Console.WriteLine("Suffix:" + Suffix).ToString();
            Resources["FindName"] = BogusGenerator.FindName("", "", false, false, "Male").ToString();
            // Console.WriteLine("FindName:" + FindName).ToString();
            Resources["JobTitle"] = BogusGenerator.JobTitle().ToString();
            // Console.WriteLine("JobTitle:" + JobTitle).ToString();
            Resources["JobDescriptor"] = BogusGenerator.JobDescriptor().ToString();
            // Console.WriteLine("JobDescriptor:" + JobDescriptor).ToString();
            Resources["JobArea"] = BogusGenerator.JobArea().ToString();
            // Console.WriteLine("JobArea:" + JobArea).ToString();
            Resources["JobType"] = BogusGenerator.JobType().ToString();
            // Console.WriteLine("JobType:" + JobType).ToString();
            Resources["PhoneNumber"] = BogusGenerator.PhoneNumber("## ### ####").ToString();
            // Console.WriteLine("PhoneNumber:" + PhoneNumber).ToString();
            Resources["PhoneNumberFormat"] = BogusGenerator.PhoneNumberFormat(0).ToString();
            // Console.WriteLine("PhoneNumberFormat:" + PhoneNumberFormat).ToString();
            Resources["Review"] = BogusGenerator.Review("product").ToString();
            // Console.WriteLine("Review:" + Review).ToString();
            Resources["Reviews"] = BogusGenerator.Reviews("product", 2).ToString();
            // Console.WriteLine("Reviews:" + Reviews).ToString();
            Resources["FileName"] = BogusGenerator.FileName(".txt").ToString();
            // Console.WriteLine("FileName:" + FileName).ToString();
            Resources["DirectoryPath"] = BogusGenerator.DirectoryPath().ToString();
            // Console.WriteLine("DirectoryPath:" + DirectoryPath).ToString();
            Resources["FilePath"] = BogusGenerator.FilePath().ToString();
            // Console.WriteLine("FilePath:" + FilePath).ToString();
            Resources["CommonFileName"] = BogusGenerator.CommonFileName(".txt").ToString();
            // Console.WriteLine("CommonFileName:" + CommonFileName).ToString();
            Resources["MimeType"] = BogusGenerator.MimeType().ToString();
            // Console.WriteLine("MimeType:" + MimeType).ToString();
            Resources["CommonFileType"] = BogusGenerator.CommonFileType().ToString();
            // Console.WriteLine("CommonFileType:" + CommonFileType).ToString();
            Resources["CommonFileExt"] = BogusGenerator.CommonFileExt().ToString();
            // Console.WriteLine("CommonFileExt:" + CommonFileExt).ToString();
            Resources["FileType"] = BogusGenerator.FileType().ToString();
            // Console.WriteLine("FileType:" + FileType).ToString();
            Resources["FileExt"] = BogusGenerator.FileExt(".txt").ToString();
            // Console.WriteLine("FileExt:" + FileExt).ToString();
            Resources["Semver"] = BogusGenerator.Semver().ToString();
            // Console.WriteLine("Semver:" + Semver).ToString();
            Resources["Version"] = BogusGenerator.Version().ToString();
            // Console.WriteLine("Version:" + Version).ToString();
            Resources["Exception"] = BogusGenerator.Exception().ToString();
            // Console.WriteLine("Exception:" + Exception).ToString();
            Resources["AndroidId"] = BogusGenerator.AndroidId().ToString();
            // Console.WriteLine("AndroidId:" + AndroidId).ToString();
            Resources["ApplePushToken"] = BogusGenerator.ApplePushToken().ToString();
            // Console.WriteLine("ApplePushToken:" + ApplePushToken).ToString();
            Resources["BlackBerryPin"] = BogusGenerator.BlackBerryPin().ToString();
            // Console.WriteLine("BlackBerryPin:" + BlackBerryPin).ToString();

        }

    }
}

