using System.Threading.Tasks;

using BoostNotes.Application.DTO.Email;

namespace BoostNotes.Application.Common.Interfaces
{
	public interface IEmailService
	{
		Task SendAsync(EmailDto email);
	}
}
