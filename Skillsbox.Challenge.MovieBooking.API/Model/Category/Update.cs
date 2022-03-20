using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Exceptions;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class Update
    {

        public class UpdateCommand : IRequest<CommandResponse>
        {
            /// <summary>
            ///     Id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            ///     Category
            /// </summary>
            public string Name { get; set; }
        }

        public class CommandResponse
        {

        }

        public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCommand>
        {
            public UpdateCategoryCommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty();

                RuleFor(x => x.Name)
                    .NotEmpty();
            }

        }

        public class CommandHandler : IRequestHandler<UpdateCommand, CommandResponse>
        {
            private readonly IUnitOfWork _repo;
            private readonly IMapper _mapper;

            public CommandHandler(IUnitOfWork repo,
                                  IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }



            public async Task<CommandResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                CommandResponse response = new();
                Core.Entities.Category entity = await _repo.CategoryRepository.GetByIdAsync(request.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException(nameof(Core.Entities.Category), request.Id);
                }
                entity.Name = request.Name;
                await _repo.CategoryRepository.UpdateAsync(entity);

                return response;
            }
        }


    }



}
