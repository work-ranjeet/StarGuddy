// -------------------------------------------------------------------------------
// <copyright file="SampleDataController.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Sample Data Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        /// <summary>
        /// The summaries
        /// </summary>
        private static string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Weathers the forecasts.
        /// </summary>
        /// <returns>
        /// Weather Forecast
        /// </returns>
        //[Authorize(Policy = "Member")]
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            });
        }

        /// <summary>
        /// Weather Forecast
        /// </summary>
        public class WeatherForecast
        {
            /// <summary>
            /// Gets or sets the date formatted.
            /// </summary>
            /// <value>
            /// The date formatted.
            /// </value>
            public string DateFormatted { get; set; }

            /// <summary>
            /// Gets or sets the temperature c.
            /// </summary>
            /// <value>
            /// The temperature c.
            /// </value>
            public int TemperatureC { get; set; }

            /// <summary>
            /// Gets or sets the summary.
            /// </summary>
            /// <value>
            /// The summary.
            /// </value>
            public string Summary { get; set; }

            /// <summary>
            /// Gets the temperature f.
            /// </summary>
            /// <value>
            /// The temperature f.
            /// </value>
            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(this.TemperatureC / 0.5556);
                }
            }
        }
    }
}
