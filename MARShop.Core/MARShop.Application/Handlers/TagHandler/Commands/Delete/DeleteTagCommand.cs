﻿using DevineShop.Application.Common;
using DevineShop.Application.Middleware;
using DevineShop.Infastructure.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevineShop.Application.Handlers.TagHandler.Commands.Delete
{
    public class DeleteTagCommand : IRequest<Respond>
    {
        public int TagId { get; set; }
    }

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Respond>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Respond> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            // check tag id exist
            var tag = await _unitOfWork.Tags.DFistOrDefaultAsync(a => a.Id == request.TagId);
            if (tag == null)
            {
                throw new AppException("Nhãn không tồn tại");
            }

            // Delete Tag
            await _unitOfWork.Tags.DDeleteAsync(tag);

            // Delete blog post tags
            await _unitOfWork.BlogPostTags.DDeleteAsync(a=>a.TagId == request.TagId);

            await _unitOfWork.SaveAsync();

            return Respond.Success();
        }
    }
}
