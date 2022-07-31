
namespace Bidding_app.Models;
List<ClientProfile> clienti = new List<ClientProfile>();
List<Card> carduri = new List<Card>();
List<CompanyProfile> companyprofiles = new List<CompanyProfile>();
List<Product> products = new List<Product>();
bool ok = true;

ClientProfile george = new ClientProfile("George");
DateTime x = DateTime.ParseExact("2023.02.02 12:30", "yyyy.MM.dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
Card c0 = new Card("1111 2222 3333 4444", "234", "233", "George", x);
clienti.Add(george);
george.AddCard(c0);
carduri.Add(c0);
george.AddMoney(c0, 1230.05);
CompanyProfile amdaris = new CompanyProfile("Amdaris", "EN2949395");
companyprofiles.Add(amdaris);
DateTime y = DateTime.ParseExact("2022.07.29 13:17", "yyyy.MM.dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
Product produsamd = new Product("laptop", 234.45, y, amdaris);
amdaris.AddProduct(produsamd);
products.Add(produsamd);
//george.AddReview(produsamd, "imi place", 5);
//george.AddReview(produsamd, "nu-mi place", 10);
while (ok)
{
    Console.WriteLine("Optiuni disponibile:");
    Console.WriteLine("1.Creare profil client;");
    Console.WriteLine("2.Vizualizare detalii client;");
    Console.WriteLine("3.Vizualizarea tuturor clientilor;");
    Console.WriteLine("4.Adaugare card nou;");
    Console.WriteLine("5.Eliminare card din cont;");
    Console.WriteLine("6.Adaugare bani in cont;");
    Console.WriteLine("7.Creare profil companie;");
    Console.WriteLine("8.Vizualizare detalii companie;");
    Console.WriteLine("9.Vizualizare companii;");
    Console.WriteLine("10.Postare produs;");
    Console.WriteLine("11.Adaugare produs in cos;");
    Console.WriteLine("12.Adauga review;");
    Console.WriteLine("13.Actualizeaza review");
    Console.WriteLine("14.Sterge review");
    Console.WriteLine("--------------------------------");
    int optiune = -1;
    try
    {
        Console.Write("\nIntroduceti optiunea: ");
        optiune = (int)Int32.Parse(Console.ReadLine());
        Console.WriteLine("--------------------------------");
        switch (optiune)
        {
            case 1:
                try
                {
                    Console.WriteLine("Optiune aleasa: creare profil client");
                    Console.Write("Introduceti numele: ");
                    string nnume = Console.ReadLine();
                    ClientProfile client = new ClientProfile(nnume);
                    clienti.Add(client);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Cont realizat cu succes!");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A aparut o eroare!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 2:
                try
                {
                    Console.WriteLine("Optiune aleasa: vizualizare profil client");
                    Console.Write("Introduceti numele: ");
                    string nnume1 = Console.ReadLine();
                    if (clienti.Find(client => client.ClientName == nnume1) == null)
                    {
                        throw new Exception();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(clienti.Find(client => client.ClientName == nnume1));

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 3:
                Console.WriteLine("Optiune aleasa: vizualizare lista profile clienti");
                Console.ForegroundColor = ConsoleColor.Green;
                clienti.ForEach(client => Console.Write(client));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------\n");
                break;
            case 4:
                try
                {
                    Console.WriteLine("Optiune aleasa: adaugare card nou");
                    Console.Write("Introduceti numele: ");
                    string nume = Console.ReadLine();
                    ClientProfile client1 = clienti.Find(client => client.ClientName == nume);
                    Console.Write("Introduceti numarul cardului: ");
                    string cardnum = Console.ReadLine();
                    Console.Write("Introduceti codul CVC: ");
                    string cvc = Console.ReadLine();
                    Console.Write("Introduceti codul pin: ");
                    string pin = Console.ReadLine();
                    string format = "yyyy.MM.dd HH:mm";
                    //DateTime x = DateTime.ParseExact("2013.07.12 15:32", format, System.Globalization.CultureInfo.InvariantCulture);
                    Console.Write("Introduceti data expirarii cardului: ");
                    string datac = Console.ReadLine();
                    DateTime data = DateTime.ParseExact(datac, format, System.Globalization.CultureInfo.InvariantCulture);
                    Card card = new Card(cardnum, cvc, pin, nume, data);
                    client1.AddCard(card);
                    carduri.Add(card);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A aparut o eroare!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 5:
                try
                {
                    Console.WriteLine("Optiune aleasa: eliminare card din cont;");
                    Console.Write("Introduceti numele: ");
                    string nume3 = Console.ReadLine();
                    if (clienti.Find(client => client.ClientName == nume3) == null)
                    {
                        throw new ArgumentNullException();
                    }
                    ClientProfile client3 = clienti.Find(client => client.ClientName == nume3);
                    Console.Write("Introduceti numarul cardului: ");
                    string cardnum3 = Console.ReadLine();
                    Card card3 = client3.FindCardByCardNumber(cardnum3);
                    if (client3.FindCardByCardNumber(cardnum3) == null)
                    {
                        throw new Exception();
                    }
                    client3.RemoveCard(card3);
                    carduri.Remove(card3);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Card eliminat cu succes!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista card cu acest numar asociat clientului selectat!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 6:
                try
                {
                    Console.WriteLine("Optiune aleasa: adaugare bani in cont;");
                    Console.Write("Introduceti suma pe care doriti sa o adaugati: ");

                    double suma = double.Parse(Console.ReadLine());
                    Console.Write("Introduceti numele: ");
                    string nume2 = Console.ReadLine();
                    if (clienti.Find(client => client.ClientName == nume2) == null)
                    {
                        throw new ArgumentNullException();
                    }
                    ClientProfile client2 = clienti.Find(client => client.ClientName == nume2);
                    Console.Write("Introduceti numarul cardului: ");
                    string cardnum2 = Console.ReadLine();
                    Console.Write("Introduceti codul CVC: ");
                    string cvc2 = Console.ReadLine();
                    Console.Write("Introduceti codul pin: ");
                    string pin2 = Console.ReadLine();
                    string format2 = "yyyy.MM.dd HH:mm";
                    //DateTime x = DateTime.ParseExact("2013.07.12 15:32", format, System.Globalization.CultureInfo.InvariantCulture);
                    Console.Write("Introduceti data expirarii cardului: ");
                    string datac2 = Console.ReadLine();
                    DateTime data2 = DateTime.ParseExact(datac2, format2, System.Globalization.CultureInfo.InvariantCulture);
                    if (client2.FindCard(new Card(cardnum2, cvc2, pin2, nume2, data2)) == null)
                    {
                        throw new Exception();
                    }
                    Card card2 = client2.FindCard(new Card(cardnum2, cvc2, pin2, nume2, data2));
                    client2.AddMoney(card2, suma);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ati introdus o valoare invalida!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista card cu aceste date asociat contului!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 7:
                try
                {
                    Console.WriteLine("Optiune aleasa: creare profil companie");
                    Console.Write("Introduceti numele companiei: ");
                    string nume1 = Console.ReadLine();
                    Console.Write("Introduceti IBAN-ul companiei: ");
                    string iban = Console.ReadLine();
                    CompanyProfile companyProfile = new CompanyProfile(nume1, iban);
                    companyprofiles.Add(companyProfile);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A aparut o eroare!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 8:
                try
                {
                    Console.WriteLine("Optiune aleasa: vizualizare profil companie");
                    Console.Write("Introduceti numele companiei: ");
                    string nume4 = Console.ReadLine();
                    Console.Write(companyprofiles.Find(client => client.CompanyName == nume4));

                }
                catch
                {
                    Console.WriteLine("Nu exista client cu acest nume");
                }
                finally
                {
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 9:
                Console.WriteLine("Optiune aleasa: vizualizare lista profile companii");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                companyprofiles.ForEach(client => Console.Write(client));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------\n");
                break;
            case 10:
                try
                {
                    Console.WriteLine("Optiune aleasa: postare produs nou");
                    Console.Write("Introduceti numele companiei: ");
                    string companyname = Console.ReadLine();
                    if (companyprofiles.Find(company => company.CompanyName == companyname) == null)
                    {
                        throw new ArgumentNullException();
                    }
                    Console.Write("Introduceti numele produsului: ");
                    string productname = Console.ReadLine();
                    Console.Write("Introduceti pretul produsului: ");
                    double price = Double.Parse(Console.ReadLine());
                    Console.Write("Introduceti timpul de expirare a licitatiei: ");
                    string datac3 = Console.ReadLine();
                    string format3 = "yyyy.MM.dd HH:mm";
                    CompanyProfile company = companyprofiles.Find(company => company.CompanyName == companyname);
                    DateTime expirare = DateTime.ParseExact(datac3, format3, System.Globalization.CultureInfo.InvariantCulture);
                    Product product = new Product(productname, price, expirare, company);
                    company.AddProduct(product);
                    products.Add(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Produs adaugat cu succes!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista companie cu acest nume!");
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ati introdus o valoare incorecta!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 11:
                try
                {
                    Console.WriteLine("Optiune aleasa: creare oferta pentru produs.");
                    Console.Write("Introduceti numele clientului: ");
                    string clientname = Console.ReadLine();
                    if (clienti.Find(c => c.ClientName == clientname) == null)
                    {
                        throw new ArgumentNullException();
                    }
                    ClientProfile cl = clienti.Find(c => c.ClientName == clientname);
                    Console.Write("Introduceti numele companiei: ");
                    string companyname1 = Console.ReadLine();
                    Console.Write("Introduceti numele produsului: ");
                    string productname1 = Console.ReadLine();
                    Product pr = products.Find(x => x.ProductName == productname1 && x.company.CompanyName == companyname1);
                    if (pr == null)
                    {
                        throw new Exception();
                    }
                    Console.Write("Introduceti suma pe care doriti sa o oferiti: ");
                    double oferta = double.Parse(Console.ReadLine());
                    cl.MakeOffer(pr, oferta);
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ati introdus o valoare incorecta!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista acest produs!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 12:
                try
                {
                    Console.WriteLine("Optiune aleasa: adaugare review;");
                    Console.Write("Introduceti numele clientului: ");
                    string clientname2 = Console.ReadLine();
                    ClientProfile cl2 = clienti.Find(c => c.ClientName == clientname2);
                    if (cl2 == null)
                    {
                        throw new ArgumentNullException();
                    }
                    Console.Write("Introduceti numele produsului pentru care doriti sa adaugati review-ul: ");
                    string numeProdus1 = Console.ReadLine();
                    Product rev = products.Find(x => x.ProductName == numeProdus1);
                    if (rev == null)
                    {
                        throw new Exception();
                    }
                    Console.WriteLine("Introduceti textul nou: ");
                    string text = Console.ReadLine();
                    Console.Write("Introduceti numarul de stele: ");
                    int nrstele = int.Parse(Console.ReadLine());
                    cl2.AddReview(rev, text, nrstele);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Review adaugat cu succes!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ati introdus o valoare incorecta!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista acest produs!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 13:
                try
                {
                    Console.WriteLine("Optiune aleasa: update review");
                    Console.Write("Introduceti numele clientului: ");
                    string clientname1 = Console.ReadLine();
                    ClientProfile cl1 = clienti.Find(c => c.ClientName == clientname1);
                    if (cl1 == null)
                    {
                        throw new ArgumentNullException();
                    }
                    Console.Write("Introduceti numele produsului unde ati adaugat review-ul: ");
                    string numeProdus = Console.ReadLine();
                    Product fffff = products.Find(x => x.ProductName == numeProdus);
                    if (fffff == null)
                    {
                        throw new Exception();
                    }
                    Review prr = products.Find(x => x.ProductName == numeProdus).Reviews.Find(x => x.Product.ProductName == numeProdus && x.Client.ClientName == clientname1);
                    if (prr == null)
                    {
                        throw new Exception();
                    }
                    Console.WriteLine("Introduceti textul nou: ");
                    string textnou = Console.ReadLine();
                    Console.Write("Introduceti numarul de stele: ");
                    int stele = int.Parse(Console.ReadLine());
                    cl1.UpdateReview(prr, textnou, stele);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Review adaugat cu succes!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ati introdus o valoare incorecta!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu ati adaugat un review acestui produs sau produsul nu exista!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            case 14:
                Console.WriteLine("Optiune aleasa: sterge review");
                try
                {
                    Console.Write("Introduceti numele clientului: ");
                    string clientname3 = Console.ReadLine();
                    ClientProfile cl3 = clienti.Find(c => c.ClientName == clientname3);
                    if (cl3 == null)
                    {
                        throw new ArgumentNullException();
                    }
                    Console.Write("Introduceti numele produsului unde ati adaugat review-ul: ");
                    string numeProdus3 = Console.ReadLine();
                    Review prr3 = products.Find(x => x.ProductName == numeProdus3).Reviews.Find(x => x.Product.ProductName == numeProdus3 && x.Client.ClientName == clientname3);
                    if (prr3 == null)
                    {
                        throw new Exception();
                    }
                    cl3.RemoveReview(prr3);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Review sters cu succes!");
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu exista client cu acest nume!");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nu aveti review adaugat la acest produs!");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------\n");
                }
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nu exista aceasta optiune!");
                break;
        }
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("A aparut o eroare;");
    }
    finally
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
}
}