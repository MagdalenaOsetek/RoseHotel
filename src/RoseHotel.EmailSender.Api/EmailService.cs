using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoseHotel.Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace RoseHotel.EmailSender.Api
{
    public class EmailService
    {
        MimeMessage message = new MimeMessage();

        


    }

    public record PaymentRequest(Reservation reservation);

    public record PaymentResponse(Guid );
}
