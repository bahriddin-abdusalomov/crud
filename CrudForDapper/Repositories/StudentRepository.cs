﻿using CrudForDapper.Interfaces;
using CrudForDapper.Models;
using CrudForDapper.Repositories;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using static Dapper.SqlMapper;

namespace CrudForDapper.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public async Task<bool> CreateAsync(Students entity)
        {
            try
            {
              await  _connection.OpenAsync();
               
                string query = "INSERT INTO public.students(id, first_name, last_name, course_id) " +
                    "VALUES (@Id, @FirstName, @LastName, @CourseId);";
                var result = await _connection.ExecuteAsync(query, entity);
                return result > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            {
               await _connection.CloseAsync();
            }
        }

  
        public async Task<bool> DeleteAsync(long Id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Delete From students Where id = @id";
                var result = await _connection.ExecuteAsync(query, new { id = Id });
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<Students>> GetAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from students;";
                var result = (await _connection.QueryAsync<Students>(query)).ToList();
                return result ;
            }
            catch
            {
                return new List<Students>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<Students> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Select * from students Where id = @Id;";
                var result = await _connection.QuerySingleAsync<Students>(query, new {Id = id});
                return result;
            }
            catch
            {
                return new Students();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<bool> UpdateAsync(Students entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE public.students SET  first_name=@FirstName, last_name=@LastName, course_id=@CourseId" +
                    $" WHERE id = {entity.Id};";
                var result = await _connection.ExecuteAsync(query, entity);
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
