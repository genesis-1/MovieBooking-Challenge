using AutoMapper;
using FluentValidation;
using MediatR;
using Skillsbox.Challenge.MovieBooking.Core.Persistence;

namespace Skillsbox.Challenge.MovieBooking.API.Model.Category
{
    public class Create
    {
        public class CreateCategoryCommand : IRequest<CommandResponse>
        {
            public string Name { get; set; }

        }


        public class CommandResponse
        {
            public int Id { get; set; }
        }

        public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public CreateCategoryCommandValidator()
            {

            }

        }

        public class CommandHandler : IRequestHandler<CreateCategoryCommand, CommandResponse>
        {
            private readonly ICategoryRepository _repo;
            private readonly IMapper _mapper;

            public CommandHandler(ICategoryRepository repo,
                                  IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<CommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                CommandResponse response = new();

                Core.Entities.Category category = _mapper.Map<Core.Entities.Category>(request);
                await _repo.AddAsync(category);
                response.Id = category.Id;
                return response;
            }
        }
    }
}
