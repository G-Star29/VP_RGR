using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Visual_Rugby.Models;
using System.Collections.Specialized;


namespace Visual_Rugby.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Result> Results { get; set; }
        public ObservableCollection<Staduim> Staduims { get; set; }
        public ObservableCollection<Tournament> Tournaments { get; set; }
        public ObservableCollection<Match> Matchs { get; set; }
        public ObservableCollection<Country> Countrys { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);

        }
        
        public MainWindowViewModel()
        {
            Teams = new ObservableCollection<Team>();
            Results = new ObservableCollection<Result>();
            Staduims = new ObservableCollection<Staduim>();
            Tournaments = new ObservableCollection<Tournament>();
            Matchs = new ObservableCollection<Match>();
            Countrys = new ObservableCollection<Country>();
            using(var db = new rugbyContext())
            {
                foreach (var team in db.Teams) Teams.Add(team);
                foreach (var result in db.Results) Results.Add(result);
                foreach (var staduim in db.Staduims) Staduims.Add(staduim);
                foreach (var tournament in db.Tournaments) Tournaments.Add(tournament);
                foreach (var match in db.Matches) Matchs.Add(match);
                foreach (var country in db.Countries) Countrys.Add(country);
            }
            Content = new DataTableViewModel();
            
        }

        public void DeleteRowTeam(Team team)
        {
            Teams.Remove(team);
            Content = new DataTableViewModel();
        }
        public void DeleteRowResult(Result result)
        {
            Results.Remove(result);
            Content = new DataTableViewModel();
        }
        public void DeleteRowMatch(Match match)
        {
            Matchs.Remove(match);
            Content = new DataTableViewModel();
        }
        public void DeleteRowCountry(Country country)
        {
            Countrys.Remove(country);
            Content = new DataTableViewModel();
        }
        public void DeleteRowStaduim(Staduim staduim)
        {
            Staduims.Remove(staduim);
            Content = new DataTableViewModel();
        }
        public void DeleteRowTournament(Tournament tournament)
        {
            Tournaments.Remove(tournament);
            Content = new DataTableViewModel();
        }
        
        public void RequestToDB()
        {
            Content = new RequestViewModel();
        }
    }
}
