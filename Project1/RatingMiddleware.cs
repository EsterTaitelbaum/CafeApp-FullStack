using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Project1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        IRatingBL _ratingBL;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingBL ratingBL)
        {
            _ratingBL = ratingBL;
            Rating r = new Rating()
            {
                Host = httpContext.Request.Host.Value,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"],
                UserAgent = httpContext.Request.Headers["User-Agent"],
                RecordDate = DateTime.Now
            };
            await ratingBL.insert(r);

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
