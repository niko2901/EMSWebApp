using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EMSWebApp.Services;

public class TicketPdfService
{
    public byte[] GenerateTicketPDF(Guid registrationId, string eventName, string FullName)
    {
        byte[] qrImageBytes = GenerateQrBytes(registrationId.ToString());

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A6);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                page.Content().Column(col =>
                {
                    col.Spacing(10);

                    col.Item().Text(eventName).Bold().FontSize(16).AlignCenter();
                    col.Item().Text($"Event Entry Pass for {FullName}").FontSize(10).FontColor(Colors.Grey.Darken1).AlignCenter();

                    col.Item().AlignCenter().Width(160).Image(qrImageBytes);

                    col.Item().Text(registrationId.ToString())
                        .Bold()
                        .FontSize(9)
                        .FontColor(Colors.Grey.Darken2)
                        .AlignCenter();
                });
            });
        });
        return document.GeneratePdf();
    }

    private byte[] GenerateQrBytes(string payload)
    {
        using var qrGenerator = new QRCodeGenerator();
        using var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(15);
    }
}
