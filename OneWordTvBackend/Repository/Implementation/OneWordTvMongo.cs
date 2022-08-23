using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using OneWordTvBackend.Helpers;
using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;
using OneWordTvBackend.Repository.Interface;

namespace OneWordTvBackend.Repository.Implementation
{
    public class OneWordTvMongo : IOneWordTvMongo
    {
        private readonly IMongoCollection<OneWordTvProgram> _programs;
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }
        public MongoDbConfig mongoDbSettings { get; set; }

        public OneWordTvMongo (IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            Configuration = configuration;
            mongoDbSettings = Configuration.GetSection(nameof(MongoDbConfig)).Get<MongoDbConfig>();
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Name);
            _programs = database.GetCollection<OneWordTvProgram>(mongoDbSettings.programsCollectionName);
        }

        public async Task<OneWordTvProgram> AddProgram(OneWordTvProgram program)
        {
            await _programs.InsertOneAsync(program);
            return program;
        }

        public async Task<ReplaceOneResult> UpdateProgram(Guid id, OneWordTvProgram program)
        {
            var result = await _programs.ReplaceOneAsync(s => s.Id == id, program);
            return result;
        }

        public Task<DeleteResult> DeleteProgram(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<OneWordTvProgram> GetProgramById(string id)
        {
            return await _programs.Find<OneWordTvProgram>(s => s.Id == Guid.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task<List<OneWordTvProgram>> GetAllPrograms()
        {
            var records = await _programs.Find(s => true).ToListAsync();
            return records;
        }

        public Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day)
        {
            throw new System.NotImplementedException();
        }
    }
}
