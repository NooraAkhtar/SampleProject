using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static TicTacToe ticTacToe;
        static bool gameOver = false;
        static void Main(string[] args)
        {
             ticTacToe = new TicTacToe();

            //Console.WriteLine("1: Print Board");
            //var input = Console.ReadLine();
            //var choice = 1;
            //if(int.TryParse(input,out choice))
            //{
            //    if(choice == 1)
            //    {
            ticTacToe.PrintBoard();
            //    }
            //}
            var isWin = false;
            while(!isWin)
            {
                isWin = PlayGame();
                ticTacToe.PrintBoard();               
            }


            ticTacToe.PrintBoard();
            if(!gameOver)
            {
                Console.WriteLine("All moves over!");
            }
            Console.Read();
        }

        private static bool PlayGame()
        {
            Console.WriteLine("Player 1: Make Choice(Row,Column):");
            string position = Console.ReadLine();

            int player1 = 1;
            int player2 = 2;

            bool isWin = ticTacToe.BoardCheck(player1, position);
            if (isWin)
            {
                gameOver = true;
                Console.WriteLine("Winner! Player 1");
                return isWin;
            }
            else { 
                ticTacToe.PrintBoard();
                Console.WriteLine("Player 2: Make Choice(Row,Column):");
                position = Console.ReadLine();
                isWin = ticTacToe.BoardCheck(player2, position);
                if(isWin)
                {
                    gameOver = true;
                    Console.WriteLine("Winner! Player 2");
                    return isWin;
                }
            }
            
            return isWin;
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {
            var helper = new Helper();

            try {
                var result = helper.GetHttpResponseAsync(1);
            }
            catch(Exception e)
            {

            }
            }
    }

    class Helper
    {
        public async Task<EmployeeResponseDTO> GetHttpResponseAsync(int id)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8088/");

            var model = new EmployeeDTO { Id = 1, Name = "John", Year = 220 };

            string postBody = JsonConvert.SerializeObject(model);
            EmployeeResponseDTO result = null;
            try
            {
                client.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

             
                var response =client.GetAsync(
                    $"gethostedsites").Result;

                //var keys = new Dictionary<string, string>();
                //keys.Add("id", "1");
                //keys.Add("name", "aa");
                //keys.Add("year", "1");

                //var response = client.PostAsJsonAsync(
                //    $"saveemployee/{model.Id}/{model.Name}/{model.Year}",
                //    new FormUrlEncodedContent(keys)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var stringText = await response.Content.ReadAsStringAsync();
                    //result = JsonConvert.DeserializeObject<EmployeeResponseDTO>();
                }
            }
            catch (Exception e)
            {

            }
            return result;// new EmployeeDTO { Id = id, Name = "Response Name", Year = 2020 };
        }

        //public async Task GetFindDetails()
        //{
        //    var client = new HttpClient();
        //    //client.BaseAddress = new Uri("http://127.0.0.1:8087/findpricechange/{isVendor}/{selectedValues}/{hostedSite}/{aBOCentralDB}");
        //    var template = new UriTemplate()
        //    try
        //    {
        //        client.DefaultRequestHeaders.Accept
        //              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = client.GetAsync(
        //            $"findpricechange").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var stringText = await response.Content.ReadAsStringAsync();
        //            //result = JsonConvert.DeserializeObject<EmployeeResponseDTO>();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }

    public class EmployeeResponseDTO
    {
        public EmployeeDTO Employee{ get; set; }
    }


    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
