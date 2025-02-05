﻿using AdformSquareAPI.Core.Dto;
using AdformSquareAPI.Core.Model;

namespace SquareApi.Core.Service
{
    public interface IPointService
    {
        Task AddAsync(Point point);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Point>> GetAllAsync();

        Task<bool> DeleteAllAsync();
    }
}
