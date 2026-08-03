using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ERP.Infrastructure.Shared
{
    public static class SqlCommandExtensions
    {
        public static void AddWithValueOrNull(this SqlParameterCollection parameters, string parameterName, object? value)
        {
            parameters.AddWithValue(parameterName, value ?? DBNull.Value);
        }
    }
}