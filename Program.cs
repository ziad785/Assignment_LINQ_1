namespace Assignment_LINQ_1
{
    using Assignment_LINQ_1.Models;
    using Assignment_LINQ_1.DataSources;
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            var result1 = Source.ProductList.Where(p => p.Category == "Seafood");
            //foreach (var p in result1)
            //{
            //    Console.WriteLine($"{p.ProductName} {p.UnitPrice:C2}");
            //}
            #endregion
            #region Q2
            var result2 = Source.ProductList
            .Select(p => new 
            { 
                p.ProductName
            });

            //foreach (var name in result2)
            //{
            //    Console.WriteLine(name);
            //}
            #endregion
            #region Q3
            var result3 = Source.ProductList.OrderBy(p => p.UnitPrice);
            //foreach(var p in result3)
            //{
            //    Console.WriteLine($"{p.ProductName} {p.UnitPrice}");
            //}
            #endregion
            #region Q4
            var result4 = Source.ProductList.Where(p => p.UnitPrice>10 && p.UnitPrice<30);
            #endregion
            #region Q5
            var result5 = Source.ProductList.Where(P => P.Category.Contains("Condiments") && P.UnitsInStock > 0);
            #endregion
            #region Q6
            var resul6 = Source.ProductList
                         .Select(p => new
                            {
                                Name = p.ProductName,
                                Price = p.UnitPrice,
                                StockStatus = p.UnitsInStock > 0
                                                ? "Available"
                                                : "Out of Stock"
                            });

            //foreach (var item in result6)
            //{
            //    Console.WriteLine(
            //        $"{item.Name} - {item.Price} - {item.StockStatus}");
            //}
            #endregion
            #region Q7
             var result7 = Source.ProductList.Select((P,I)=> new 
            {
               Name = P.ProductName,
               Index = I+1
            });
            //foreach (var item in result7)
            //{
            //    Console.WriteLine($"{item.Index}.{item.Name}");
            //}
            #endregion
            #region Q8 
            var result8 = Source.ProductList.OrderBy(P => P.Category).ThenByDescending(P=> P.UnitPrice);
            #endregion
            #region Q9
            var result9 = Source.ProductList.Where(P => P.Category == "Beverages")
                .OrderByDescending(P=> P.UnitsInStock);

            //foreach (var item in result9)
            //{
            //    Console.WriteLine($"{item.ProductName} - {item.UnitsInStock}");
            //}
            #endregion
            #region Q10

            var result10 =
                from c in Source.CustomerList
                from o in c.Orders
                where o.OrderDate.Year >= 1997
                select new
                {
                    c.CustomerID,
                    o.OrderDate
                };

            //foreach (var order in result10)
            //{
            //    Console.WriteLine(
            //        $"{order.CustomerID} - {order.OrderDate}");
            //}

            #endregion
            #region Q11
            var result11 = Source.ProductList
                .Select((p, index) => new
                {
                    Position = index + 1,
                    p.ProductName
                });

            //foreach (var item in result11)
            //{
            //    Console.WriteLine($"{item.Position}. {item.ProductName}");
            //}

            #endregion
            #region Q12
            string[] Arr =
            {
               "Aile1",
               "Aile2",
               "Aile3",
               "aPPLE",
               "AbAcUs",
               "bRaNcH",
               "BlUeBeRrY",
               "ClOvEr",
               "cHeRry"
            };
            var result12 = Arr.OrderBy(word => word.Length).ThenBy(word=> word,StringComparer.OrdinalIgnoreCase);
            //foreach(var t in result12) 
            //{
            //    Console.WriteLine(t);
            //}
            #endregion
            #region Q13
            var result13 = Arr.Where(Word => Word.Length > 1 && char.ToLower(Word[1]) == 'i')
                        .Reverse().ToList();
            foreach (var word in result13)
            {
                Console.WriteLine(word);
            }

            #endregion
           
        }
    }
}
