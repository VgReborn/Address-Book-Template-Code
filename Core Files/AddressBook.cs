using FileType;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mime;
using System.Text.Json;

#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS0649
#pragma warning disable CS8601

namespace ABook
{
    static class AddressBook
    {
        #nullable enable
        
        public const string DEFAULT = "Not provided";
        public static List<Information> AddressBooks = new List<Information>();
        public static void Show()
        {
            foreach(Information _ in AddressBooks)
                Console.WriteLine($"Name: {_.Name}\nAddress: {_.Address}\nPhone: {_.Phone}\nEmail: {_.Email}");
        }


        /// <summary>
        /// This brings in the contents from the file into temporary data, effectively copying it so it can be manipulated directly without changing anything from the file<br/>
        /// Once finish, the temp data will be stored under the "temp" folder, which can be reused when needed to (can only store 1 temp file at a time)
        /// </summary>
        /// <param name="path">the path the file works on</param> 
        /// <param name="writeToTempData">Check whether or not you want to write into temp data</param>
        public static void GetFile(string path = "", bool writeToTempData = false, bool useTempData=false)
        {
            string _content = "";

            if(useTempData && path != "") throw new ArgumentException("the useTempData cannot be true whenever the path is not set to \"\"");

            if(!useTempData && path != "") _content = File.ReadAllText(path);
            if(useTempData && path == "") _content = GetTempFile();

            if(_content is null || _content == "") throw new NullReferenceException("_content cannot be null or its value cannot be \"\""); 


            if(!Check.IsJson(_content)) return;
            
            JObject _jObject = JObject.Load(new JsonTextReader(File.OpenText(path)));
            Input(_jObject);
            if(writeToTempData)
                _CreateTempFile(_content);
        }
        private static void Input(JObject _content)
        {
            try 
            {
                JArray _information = (JArray)_content["information"];
                foreach (var __information in _information)
                {
                    Information info = new Information() 
                    {
                        Name = (string)__information["Name"],
                        Address = (string)__information["Address"],
                        Phone = (string)__information["Phone"],
                        Email = (string)__information["Email"]
                    };

                    Add(info);
                }
            }
            catch
            {
                throw new Newtonsoft.Json.JsonException("There is a token that may not be found, unreadable, or in the wrong format");
            }
        }
        /// <summary>
        /// This creates the temp file after using the GetFile() method. There are already measures to ensure that the temp file is created correctly
        /// </summary>
        /// <exception cref="ArgumentException">The contents cannot be null or empty</exception>
        private static void _CreateTempFile([NotNull]string contents)
        {
            if(contents is null) throw new ArgumentException("the argument cannot be null");

            
            string tempDirectory = string.Concat(Directory.GetCurrentDirectory(), "\\temp");
            string tempFilePath = string.Concat(tempDirectory, "\\tempData.json");

            if(!Directory.Exists(tempDirectory)) Directory.CreateDirectory("temp");

            if(!File.Exists(tempFilePath)) {
                FileStream fs = File.Create(tempFilePath);
                fs.Close();
            };

            FileStream _fs = File.Open(tempFilePath, FileMode.Open); //To ensure there will be no IO exceptions when trying to access the same file
            Console.WriteLine(contents);
            byte[] _contents = new UTF8Encoding(true).GetBytes(contents);

            _fs.Write(_contents);
            _fs.Close();
            _fs.Dispose();
        }

        
        
        //probaby bad coding practice ngl
        
        
        public static void Add(string _name=DEFAULT, string _address=DEFAULT, string _phone=DEFAULT, string _email=DEFAULT)
        {
            Information _information = new Information() 
            {
                Name = _name,
                Address = _address,
                Phone = _phone,
                Email = _email
            };
            Add(_information);
        }
        internal static void _DeleteTempFile() =>
            File.Delete(string.Concat(Directory.GetCurrentDirectory(), "\\temp\\tempData.json"));

        private static string GetTempFile() 
        {
            string _tempPath= string.Concat(Directory.GetCurrentDirectory(), "\\temp\\tempData.json");
            if(File.Exists(_tempPath))
                return File.ReadAllText(string.Concat(Directory.GetCurrentDirectory(), "\\temp\\tempData.json"));
            
            throw new FileNotFoundException("the tempData.json file cannot be found. Either it is deleted, renamed, or there is no temp file ");
        }
        public static void Delete(Information _information) => AddressBooks.Remove(_information);
        public static void Add(Information information) => AddressBooks.Add(information);
        
        #nullable disable
    }
}