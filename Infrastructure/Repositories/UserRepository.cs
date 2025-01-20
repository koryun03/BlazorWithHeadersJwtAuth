using Dapper;
using Domain.Dto;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UserRepository(ISqlConnectionFactory _connectionFactory) : IUserRepository
    {
        public async Task Insert(UserDto dto)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                const string query = @"insert into UserEntity(Login,HashedPassword)
                                     Values(@Login,@Password);";

                await connection.ExecuteAsync(query, new { dto.Login, dto.Password });
            }
        }

        public async Task<UserDto> GetUserByLogin(string login)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                const string query = @"select * from UserEntity where Login=@Login";

                var user = await connection.QueryFirstOrDefaultAsync<UserEntity>(query, new { login });
                if (user == null)
                {
                    return null;
                }
                return new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.HashedPassword,
                };
            }
        }


        //public async Task ResetPassword(UserDto dto)
        //{
        //    using (var connection = _connectionFactory.CreateConnection())
        //    {
        //        await connection.OpenAsync();
        //        const string query = @"
        //            insert into Users(Login,HashedPassword)
        //            Values(@Login,@HashedPassword);";

        //        await connection.ExecuteAsync(query, new { dto.Login, dto.Password });
        //    }
        //}

    }
}
