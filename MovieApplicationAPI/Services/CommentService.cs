﻿using AutoMapper;
using MovieAppAPI.Data;
using MovieAppAPI.Dto;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;
using System.ComponentModel.Design;

namespace MovieAppAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateMovieCommentAsync(CommentCreateDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _unitOfWork.CommentRepo.CreateCommentAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMovieCommentAsync(int MovieId, CommentCreateDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _unitOfWork.CommentRepo.CreateMovieCommentAsync(MovieId, comment);
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            await _unitOfWork.CommentRepo.DeleteCommentAsync(commentId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<CommentDto>> GetAllCommentAsync()
        {
            var comment = await _unitOfWork.CommentRepo.GetAllCommentAsync();

            var commentDto = _mapper.Map<List<CommentDto>>(comment);
            return commentDto;
        }

        public async Task<CommentDto> GetCommentAsync(int commentId)
        {
            var comment = await _unitOfWork.CommentRepo.GetByCommentIdAsync(commentId);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }

        public async Task<List<CommentDto>> GetMovieCommentAsync(int MovieId)
        {
            var movieComment = await _unitOfWork.CommentRepo.GetByMovieCommentIdAsync(MovieId);
            var movieCommentDto = _mapper.Map<List<CommentDto>>(movieComment);
            return movieCommentDto;
        }

        public async Task<bool> UpdateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);

            await _unitOfWork.CommentRepo.UpdateCommentAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
