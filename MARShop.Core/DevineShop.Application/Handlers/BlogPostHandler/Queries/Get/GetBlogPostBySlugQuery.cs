﻿using DevineShop.Application.Common;
using MediatR;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;
using DevineShop.Infastructure.UnitOfWork;
using DevineShop.Application.Mapper;
using DevineShop.Application.Middleware;
using System.Linq;

namespace DevineShop.Application.Handlers.BlogPostHandler.Queries.Get
{
    public class GetBlogPostBySlugQuery : IRequest<Respond<BlogPostBySlugRespond>>
    {
        public string Slug { get; set; }
    }
    public class BlogPostBySlugRespond
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public IList<TagBySlugRespond> Tags { get; set; }
    }
    public class TagBySlugRespond
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class GetBlogPostBySlugQueryHandle : IRequestHandler<GetBlogPostBySlugQuery, Respond<BlogPostBySlugRespond>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBlogPostBySlugQueryHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Respond<BlogPostBySlugRespond>> Handle(GetBlogPostBySlugQuery request, CancellationToken cancellationToken)
        {
            var blogPost = await _unitOfWork.BlogPosts.DFistOrDefaultAsync(a => a.Slug == request.Slug);

            // check blog post exist
            if (blogPost == null) throw new AppException("Bài viết không tồn tại");

            // increate view
            blogPost.Views += 1;
            await _unitOfWork.BlogPosts.DUpdateAsync(blogPost);
            await _unitOfWork.SaveAsync();

            // map to respond
            var blogPostRespond = BlogPostMapper.Mapper.Map<BlogPostBySlugRespond>(blogPost);
            blogPostRespond.Likes = GetLikes(blogPost.Id);
            blogPostRespond.Tags = await GetTagResponds(blogPost.Id);

            return Respond<BlogPostBySlugRespond>.Success(blogPostRespond);
        }
        private async Task<IList<TagBySlugRespond>> GetTagResponds(int blogPostId)
        {
            var blogPostTags = _unitOfWork.BlogPostTags.DGet(a => a.BlogPostId == blogPostId).ToList();

            var tags = new List<TagBySlugRespond>();
            foreach (var blogPostTag in blogPostTags)
            {
                var tagss = _unitOfWork.Tags.DGetDbSet();
                var tag = await _unitOfWork.Tags.DFistOrDefaultAsync(a => a.Id == blogPostTag.TagId);
                tags.Add(new TagBySlugRespond()
                {
                    Id = tag.Id,
                    Title = tag.Title,
                });
            }
            return tags;
        }
        private int GetLikes(int blogPostId)
        {
            return _unitOfWork.AccountBlogPosts.DGet(a => a.BlogPostId == blogPostId && a.IsLiked == true).Count();
        }
    }
}
