﻿using FluentValidation.Results;

namespace Skillsbox.Challenge.MovieBooking.API.Infrastructure.ApiExceptions
{
    public class ApiModelValidationException : Exception
    {
        /// <summary>
        ///     Validation errors
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }

        /// <summary>
        ///     ctor
        /// </summary>
        public ApiModelValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        ///     ctor 
        /// </summary>
        /// <param name="failures"></param>
        public ApiModelValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}
