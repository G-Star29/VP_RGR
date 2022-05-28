using ReactiveUI;
using System.Collections.ObjectModel;
using Visual_Rugby.Models;


namespace Visual_Rugby.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        private ObservableCollection<Team> _teams;
        private ObservableCollection<Result> _results;
        private ObservableCollection<Staduim> _staduims;
        private ObservableCollection<Tournament> _tournaments;
        private ObservableCollection<Match> _matchs;
        private ObservableCollection<Country> _countrys;
        rugbyContext data;
        public rugbyContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }                                    
       
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);

        }
        
        public ObservableCollection<Team> Teams
        {
            get => _teams;
            set => this.RaiseAndSetIfChanged(ref _teams, value);
        }

        public ObservableCollection <Result> Results
        {
            get => _results;
            set => this.RaiseAndSetIfChanged(ref _results, value);
        }

        public ObservableCollection<Staduim> Staduims
        {
            get => _staduims;
            set => this.RaiseAndSetIfChanged(ref _staduims, value);
        }

        public ObservableCollection<Tournament> Tournaments
        {
            get => _tournaments;
            set => this.RaiseAndSetIfChanged(ref _tournaments, value);
        }

        public ObservableCollection<Match> Matches
        {
            get => _matchs;
            set => this.RaiseAndSetIfChanged(ref _matchs, value);
        }

        public ObservableCollection<Country> Countries
        {
            get => _countrys;
            set => this.RaiseAndSetIfChanged(ref _countrys, value);
        }

        public MainWindowViewModel()
        {
            Teams = new ObservableCollection<Team>();
            Results = new ObservableCollection<Result>();
            Staduims = new ObservableCollection<Staduim>();
            Tournaments = new ObservableCollection<Tournament>();
            Matches = new ObservableCollection<Match>();
            Countries = new ObservableCollection<Country>();
            using(var db = new rugbyContext())
            {
                foreach (var team in db.Teams) Teams.Add(team);
                foreach (var result in db.Results) Results.Add(result);
                foreach (var staduim in db.Staduims) Staduims.Add(staduim);
                foreach (var tournament in db.Tournaments) Tournaments.Add(tournament);
                foreach (var match in db.Matches) Matches.Add(match);
                foreach (var country in db.Countries) Countries.Add(country);
            }
            Content = new DataTableViewModel();
            
        }

        public void DeleteRowTeam(Team team)
        {
            Teams.Remove(team);
         
        }
        public void DeleteRowResult(Result result)
        {
            Results.Remove(result);
            
        }
        public void DeleteRowMatch(Match match)
        {
            Matches.Remove(match);
            
        }
        public void DeleteRowCountry(Country country)
        {
            Countries.Remove(country);
            
        }
        public void DeleteRowStaduim(Staduim staduim)
        {
            Staduims.Remove(staduim);
            
        }
        public void DeleteRowTournament(Tournament tournament)
        {
            Tournaments.Remove(tournament);
        }
        

        private void NewRowTeam() => Teams.Add(new Team());
        private void NewRowResult() => Results.Add(new Result());
        private void NewRowCountry() => Countries.Add(new Country());
        private void NewRowMatch() => Matches.Add(new Match());
        private void NewRowStaduim() => Staduims.Add(new Staduim());
        private void NewRowTournament() => Tournaments.Add(new Tournament());
        private void SaveChangesToBD()
        {
            var db = new rugbyContext();
            db.SaveChanges();
        }
        private void GoToMainMenu()
        {
            Content = new DataTableViewModel();
        }
        public void RequestToDB()
        {
            Content = new RequestViewModel();
        }
    }
}
