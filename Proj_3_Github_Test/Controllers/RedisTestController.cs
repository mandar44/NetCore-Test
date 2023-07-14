using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Proj_3_Github_Test.Models;

namespace Proj_3_Github_Test.Controllers
{
    public class RedisTestController : Controller
    {
        // GET: RedisTestController
        public ActionResult Index()
        {
            RedisCache r1 = new RedisCache();
            r1.key1 = "TestKey1";
            r1.value1="A";
            return View(r1);

            //return View();

            //  Console on Azure Portal //
                //get "TestKey1"
                //"Asdfgh"
                //> set "TestKey1" "aa"
                //OK
                //> get "TestKey1"
                //"aa"
            //
        }

        [HttpPost]
        public ActionResult Save(RedisCache Redis)
        {
            var connectionString = "CoreGitHubV1.redis.cache.windows.net:6380,password=M1IWtLAGjHH0vpN4t3TRBASV9hH5HF5bmAzCaJxoCU8=,ssl=True,abortConnect=False";
            //"[cache-name].redis.cache.windows.net:6380,password=[password-here],ssl=True,abortConnect=False";
            var redisConnection = ConnectionMultiplexer.Connect(connectionString);
            IDatabase db = redisConnection.GetDatabase();

            //bool wasSet = db.StringSet("TestKey1", "Value 1");
            //bool wasSet = db.StringSet("TestKey1", Value1);

            bool wasSet = db.StringSet(Redis.key1.ToString(), Redis.value1.ToString());

            string value1 = db.StringGet(Redis.key1.ToString());
            ViewBag.value1 = value1.ToString();

            redisConnection.Dispose();
            redisConnection = null;
            ////Console.WriteLine(value1); 
            
            return View("Index");
        }

        // GET: RedisTestController/
        public ActionResult Show()
        {
            return View();
        }

        //// POST: RedisTestController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RedisTestController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RedisTestController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RedisTestController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RedisTestController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
