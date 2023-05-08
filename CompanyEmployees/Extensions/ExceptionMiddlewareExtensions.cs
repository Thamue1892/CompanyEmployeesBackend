﻿using Contracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;

namespace CompanyEmployees.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType =
                        "application/json; charset=utf-8";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                         
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}