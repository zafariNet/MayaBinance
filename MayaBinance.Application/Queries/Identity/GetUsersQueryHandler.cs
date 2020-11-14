using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MayaBinance.Application.Configs;
using MayaBinance.Application.Dtos.Identity;
using MayaBinance.Domain;
using MayaBinance.Shared.utils;
using MediatR;
using Microsoft.Data.SqlClient;

namespace MayaBinance.Application.Queries.Identity
{
    public class GetUsersQueryHandler:IRequestHandler<GetUsersQuery,QueryResponse<List<SimpleUserViewModel>>>
    {
        private readonly DatabaseConnection _connection;

        public GetUsersQueryHandler(DatabaseConnection connection)
        {
            _connection = connection;
        }


        public async Task<QueryResponse<List<SimpleUserViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            await using (var connection = new
                SqlConnection(_connection.ConnectionString))
            {
                QueryResponse<List<SimpleUserViewModel>> response;
                try
                {
                    connection.Open();
                    var result = await connection.QueryAsync<SimpleUserViewModel>(@"
                    SELECT TOP (1000) [Id]
                          ,[FirstName]
                          ,[LastName]
                          ,[EmailOrUserName]
                      FROM [MayaBinance].[identity].[Users]", new { });
                    var list = result.AsList();
                    response =new
                        QueryResponse<List<SimpleUserViewModel>>(list, list.Count);
              
                }
                catch (Exception e)
                {
                    List<string> errors = new List<string> { e.Message };
                    if (e.InnerException != null)
                        errors.Add(e.InnerException.Message);


                    response= new
                        QueryResponse<List<SimpleUserViewModel>>(null, 0)
                        {
                            ErrorMessage = ExceptionHandler.GetError(e)
                    };
                }

                return response;

            }
        }
    }
}
