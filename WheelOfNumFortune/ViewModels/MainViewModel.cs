using Avalonia.Threading;
using Material.Styles.Controls;
using ReactiveUI;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WheelOfNumFortune.ViewModels;

public class MainViewModel : ViewModelBase
{
    private  Task<HttpResponseMessage> httpResponse;
    private  HttpClient client = new HttpClient();
    private  Task<string> sTask;

    private  String _risposta;
    private String _visualizzazione;
    private String _status;
    private string parola;
    private bool _abilitaDiscoverLetter;
    private bool _abilitaCheckRisposta;

    private bool _abilitaRisposta;
    public bool AbilitaRisposta { get => _abilitaRisposta; set => this.RaiseAndSetIfChanged(ref _abilitaRisposta, value); }

    public bool AbilitaCheckRisposta { get => _abilitaCheckRisposta; set => this.RaiseAndSetIfChanged(ref _abilitaCheckRisposta, value); }

    public bool AbilitaDiscoverLetter { get => _abilitaDiscoverLetter; set => this.RaiseAndSetIfChanged(ref _abilitaDiscoverLetter, value); }
    public String Risposta { get => _risposta; set => this.RaiseAndSetIfChanged(ref _risposta, value); }
    public String Visualizzazione { get => _visualizzazione; private set => this.RaiseAndSetIfChanged(ref _visualizzazione, value); }
    private  int i;
    public string Status { get => _status; set
        {
            this.RaiseAndSetIfChanged(ref _status, value);
            SnackbarHost.Post(_status, null, DispatcherPriority.Normal);
        }
    }
    private StringBuilder sb;
    private  Random random = new Random();
    public ICommand Tick { get; private set; }
    public ICommand CheckRisposta { get; private set; }

    public ICommand DiscoverLetter { get; private set; }

    public MainViewModel()
    {
        Tick = ReactiveCommand.Create(tick);
        CheckRisposta = ReactiveCommand.Create(checkRisposta);
        DiscoverLetter = ReactiveCommand.Create(discoverLetter);
        tick();
    }
    public void tick()
    {
        try
        {
            httpResponse = client.GetAsync("https://helloacm.com/api/fortune/");

            if (httpResponse.Result.IsSuccessStatusCode)
            {

                sTask = httpResponse.Result.Content.ReadAsStringAsync();
                parola = sTask.Result;
                parola = parola.Substring(1, parola.Length - 2);
                parola = parola.Replace("\\n", "\r\n");
                parola = parola.Replace("\\t", "    ");
                parola = parola.Replace("\\\"", "\"");
                parola = parola.Replace("\\b", "");
                parola = parola.Trim();
                sb = new StringBuilder(parola);
                for (i = 0; i < sb.Length; i++)
                    switch (sb[i])
                    {
                        case 'q':
                        case 'Q':
                        case 'w':
                        case 'W':
                        case 'e':
                        case 'E':
                        case 'r':
                        case 'R':
                        case 't':
                        case 'T':
                        case 'y':
                        case 'Y':
                        case 'u':
                        case 'U':
                        case 'i':
                        case 'I':
                        case 'o':
                        case 'O':
                        case 'p':
                        case 'P':
                        case 'a':
                        case 'A':
                        case 's':
                        case 'S':
                        case 'd':
                        case 'D':
                        case 'f':
                        case 'F':
                        case 'g':
                        case 'G':
                        case 'h':
                        case 'H':
                        case 'j':
                        case 'J':
                        case 'k':
                        case 'K':
                        case 'l':
                        case 'L':
                        case 'z':
                        case 'Z':
                        case 'x':
                        case 'X':
                        case 'c':
                        case 'C':
                        case 'v':
                        case 'V':
                        case 'b':
                        case 'B':
                        case 'n':
                        case 'N':
                        case 'm':
                        case 'M':
                            sb[i] = '*';
                            break;


                    }
                Visualizzazione = sb.ToString();
                AbilitaRisposta = true;
                AbilitaDiscoverLetter = true;
                AbilitaCheckRisposta = true;
            }
            else
            {
                Status = $"The HTTP status code is ${httpResponse.Result.StatusCode}";
            }
        }
        catch (InvalidOperationException ex)
        {
            Status = ex.Message;
            AbilitaRisposta = false;
            AbilitaDiscoverLetter = false;
            AbilitaCheckRisposta = false;
        }
        catch (AggregateException ex)
        {
            Status = ex.Message;
            AbilitaRisposta = false;
            AbilitaDiscoverLetter = false;
            AbilitaCheckRisposta = false;

        }
    }
    private void checkRisposta()
    {
        if (parola == Risposta)
        {
            Status = "You are right";
            AbilitaDiscoverLetter = false;
            AbilitaCheckRisposta = false;
        }
        else
            Status = "You are wrong";
    }


    private void discoverLetter()
    {
        i = random.Next(0, sb.Length);
        while (sb[i] != '*' && Visualizzazione.IndexOf("*") != -1)
        {
            i++;
            if (i == sb.Length)
                i = 0;
        }
        sb[i] = parola[i];
        Visualizzazione = sb.ToString();
        if (Visualizzazione.IndexOf('*') == -1)
        {
            Status = "You have lost";
            AbilitaDiscoverLetter = false;
            AbilitaCheckRisposta = false;
        }
    }

    public bool ObtainedResponse()
    {
        bool ex = false;
        try
        {
            ex = httpResponse.Result.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            ex = false;
        }
        return ex;
    }
}
