﻿using LorryGlory.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Helpers
{
    /// <summary>
    /// Handles API responses with appropriate logging and status codes
    /// </summary>
    public static class ResponseHelper
    {
        /// <summary>
        /// Handles successful operations by logging the message and returning an OK result
        /// </summary>
        /// <typeparam name="T">The type of data being returned</typeparam>
        /// <param name="logger">The logger instance</param>
        /// <param name="data">The data to be returned</param>
        /// <param name="message">The success message</param>
        /// <returns>An OK (200) result with the data and success message</returns>
        public static ActionResult<ApiResponse<T>> HandleSuccess<T>(ILogger logger, T data, string message)
        {
            logger.LogInformation(message);
            return new OkObjectResult(new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message
            });
        }

        /// <summary>
        /// Handles unexpected exceptions during API operations
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleException<T>(ILogger logger, Exception ex)
        {
            logger.LogError(ex, "An unexpected error occurred: {ExceptionType}", ex.GetType().Name);
            return new ObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = "An unexpected error occurred.",
                Errors = new[] { ex.Message }
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        /// <summary>
        /// Handles bad request scenarios
        /// </summary>
        /// 
        // For exception-based bad requests
        public static ActionResult<ApiResponse<T>> HandleBadRequest<T>(ILogger logger, Exception ex)
        {
            logger.LogWarning(ex, "Invalid operation: {ExceptionType}", ex.GetType().Name);
            return new BadRequestObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = "Invalid operation.",
                Errors = new[] { ex.Message }
            });
        }

        // For validation-based bad requests
        public static ActionResult<ApiResponse<T>> HandleBadRequest<T>(ILogger logger, string message)
        {
            logger.LogWarning("Invalid operation: {Message}", message);
            return new BadRequestObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = "Invalid operation.",
                Errors = new[] { message }
            });
        }

        /// <summary>
        /// Handles not found scenarios
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleNotFound<T>(ILogger logger, string message)
        {
            logger.LogWarning(message);
            return new NotFoundObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new[] { message }
            });
        }

        /// <summary>
        /// Handles conflict scenarios
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleConflict<T>(ILogger logger, string message)
        {
            logger.LogWarning(message);
            return new ConflictObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new[] { message }
            });
        }

        /// <summary>
        /// Handles validation exceptions
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleValidationException<T>(ILogger logger, ValidationException ex)
        {
            logger.LogWarning(ex, "Validation error: {Message}", ex.Message);
            return new BadRequestObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = "Validation error occurred",
                Errors = new[] { ex.Message }
            });
        }

        /// <summary>
        /// Handles concurrency exceptions
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleConcurrencyException<T>(ILogger logger, DbUpdateConcurrencyException ex)
        {
            logger.LogWarning(ex, "Concurrency conflict detected");
            return new ConflictObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = "Concurrency error occurred",
                Errors = new[] { "The record has been modified by another user" }
            });
        }

        /// <summary>
        /// Handles database-related errors
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleDatabaseError<T>(
            ILogger logger,
            Exception ex,
            string userMessage = "A database error occurred while processing your request.")
        {
            logger.LogError(ex, "Database error: {ErrorMessage}", ex.Message);

            return new ObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = userMessage,
                Errors = new[] { userMessage }
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        /// <summary>
        /// Handles unauthorized access attempts
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleUnauthorized<T>(ILogger logger, string message = "Unauthorized access")
        {
            logger.LogWarning("Unauthorized access attempt");
            return new UnauthorizedObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new[] { message }
            });
        }

        /// <summary>
        /// Handles forbidden access attempts
        /// </summary>
        public static ActionResult<ApiResponse<T>> HandleForbidden<T>(ILogger logger, string message = "Access forbidden")
        {
            logger.LogWarning("Forbidden access attempt: {Message}", message);
            return new ObjectResult(new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new[] { message }
            })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
    }
}