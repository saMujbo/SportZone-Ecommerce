using System.Net.Mail;
using System.Net;
using Entidades;
using Services.Shoe;

namespace Services.NewFolder
{
        class Mail
        {
            public string sendMail(string to, string asunto, string body)
            {
                string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
                string from = "jdromfer16@outlook.es";
                string displayName = "Factura";
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from, displayName);
                    mail.To.Add(to);

                    mail.Subject = asunto;
                    mail.Body = body;
                    mail.IsBodyHtml = true;


                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                    client.Credentials = new NetworkCredential(from, "JosDani07");
                    client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                    client.Send(mail);
                    msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

                }
                catch (Exception ex)
                {
                    msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
                }

                return msge;
            }

            public string GenerateHtml(List<PurchaseDetail> purchaseDetails, Entidades.Invoice invoice, Entidades.Customer customer)
            {
                string fechaCompra = invoice.InvoiceDate.ToString("dd/MM/yyyy");
                string fechaVencimiento = invoice.DevolutionDate.ToString("dd/MM/yyyy");
                SvShoe svShoe = new SvShoe();
                var html = @"
                    <html>
                    <head>
                        <style>
                            body { font-family: Arial, sans-serif; }
                            h2 { color: #2E86C1; }
                            table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                            th, td { padding: 12px; border: 1px solid #ddd; text-align: left; }
                            th { background-color: #333; color: white; }
                            tr:nth-child(even) { background-color: #f2f2f2; } /* Aplica color gris a filas pares */
                            .totals { margin-top: 20px; }
                            .totals h3 { margin: 5px 0; }
                            .totals div { text-align: right; margin-right: 20px; }
                            .payment-method { margin-top: 20px; }
                            .payment-method p { margin: 5px 0; }
                            .total-amount { font-size: 1.5em; font-weight: bold; }
                        </style>
                    </head>
                    <body>
                        <h2>Factura</h2>
                        <p><strong>Nombre del Cliente:</strong> " + customer.Name + @"</p>
                        <p><strong>Fecha Compra :</strong> " + fechaCompra + @"</p>
                        <p><strong>Factura #:</strong> " + invoice.Id + @"</p>

                        <table>
                            <tr>
                                <th>PRODUCTOS</th>
                                <th>CANTIDAD</th>
                                <th>PRECIO</th>
                                <th>TOTAL</th>
                            </tr>";

                foreach (var detail in purchaseDetails)
                {
                    Entidades.Shoe shoe = svShoe.GetShoeById(detail.ShoeId);
                    html += $@"
                            <tr>
                                <td>{shoe.Name}</td>
                                <td>{detail.Quantity}</td>
                                <td>{shoe.Price}</td>
                                <td>{detail.Subtotal}</td>
                            </tr>";
                }

                html += $@"
                        </table>
                        <div class='totals'>
                            <div><strong>Sub-total : $</strong> {(decimal)invoice.SubTotal}</div>
                            <div><strong>Iva: $</strong> {(decimal)invoice.IVA}</div>
                            <div class='total-amount'><strong>Total : $</strong> {(decimal)invoice.Total}</div>
                            <p><strong>Fecha Vencimiento Factura :</strong> " + fechaVencimiento + @"</p>
                        </div>

                    </body>
                    </html>";

                return html;
            }
        }

}
