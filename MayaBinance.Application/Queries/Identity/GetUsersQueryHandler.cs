using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Dapper;
using MayaBinance.Application.Configs;
using MayaBinance.Application.Dtos.Identity;
using MayaBinance.Domain;
using MediatR;
using Microsoft.Data.SqlClient;

namespace MayaBinance.Application.Queries.Identity
{
    public class GetUsersQueryHandler:IRequestHandler<GetUsersQuery,GetGeneralResponse<List<SimpleUserViewModel>>>
    {
        private readonly DatabaseConnection _connection;

        public GetUsersQueryHandler(DatabaseConnection connection)
        {
            _connection = connection;
        }


        public async Task<GetGeneralResponse<List<SimpleUserViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            using (var connection = new
                SqlConnection(_connection.ConnectionString))
            {
                GetGeneralResponse<List<SimpleUserViewModel>> response;
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
                        GetGeneralResponse<List<SimpleUserViewModel>>(list, list.Count,false, null);
              
                }
                catch (Exception e)
                {
                    List<string> errors = new List<string> { e.Message };
                    if (e.InnerException != null)
                        errors.Add(e.InnerException.Message);


                    response= new
                        GetGeneralResponse<List<SimpleUserViewModel>>(null, 0,true, e.Message);
                }

                return response;

            }
        }
    }
}
