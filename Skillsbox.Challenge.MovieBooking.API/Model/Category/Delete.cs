using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Exceptions;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class Delete
    {
        public class DeleteCategoryCommand : IRequest<CommandResponse>
        {
            public int Id { get; set; }
        }


        public class CommandResponse
        {

        }


        public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public DeleteCategoryCommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty();
            }

        }


        public class CommandHandler : IRequestHandler<DeleteCategoryCommand, CommandResponse>
        {
            private readonly IUnitOfWork _repo;
            private readonly IMapper _mapper;

            public CommandHandler(IUnitOfWork repo, IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CommandResponse> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
            {
                CommandResponse response = new();

                Core.Entities.Category category = await _repo.CategoryRepository.GetByIdAsync(command.Id);

                if(category == null)
                {
                    throw new EntityNotFoundException(nameof(Category), command.Id);
                }

                await _repo.CategoryRepository.DeleteAsync(category);

                return response;
            }


        }



    }
}
