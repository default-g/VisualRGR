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
using CursWorkAvalonia.Models;
using System.Collections.Specialized;


namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request,value);
        }

        private ObservableCollection<Country> _countries;
        private ObservableCollection<Gender> _genders;
        private ObservableCollection<Match> _matches;
        private ObservableCollection<Place> _places;
        private ObservableCollection<Player> _players;
        private ObservableCollection<Tournament> _tournaments;





        public ObservableCollection<Country> Countries
        {
            get => _countries;
            set => this.RaiseAndSetIfChanged(ref _countries, value);
        }
        public ObservableCollection<Gender> Genders
        {
            get => _genders;
            set => this.RaiseAndSetIfChanged(ref _genders, value);
        }
        public ObservableCollection<Match> Matches
        {
            get => _matches;
            set => this.RaiseAndSetIfChanged(ref _matches, value);
        }
        public ObservableCollection<Place> Places
        {
            get => _places;
            set => this.RaiseAndSetIfChanged(ref _places, value);
        }
        public ObservableCollection<Player> Players
        {
            get => _players;
            set => this.RaiseAndSetIfChanged(ref _players, value);
        }
        public ObservableCollection<Tournament> Tournaments
        {
            get => _tournaments;
            set => this.RaiseAndSetIfChanged(ref _tournaments, value);
        }
        
        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        
        public MainWindowViewModel()
        {

            using(var db = new dartsContext())
            {
                this.Players = new ObservableCollection<Player>(db.Players);
                this.Countries = new ObservableCollection<Country>(db.Countries);
                this.Genders = new ObservableCollection<Gender>(db.Genders);
                this.Matches = new ObservableCollection<Match>(db.Matches);
                this.Places = new ObservableCollection<Place>(db.Places);
                this.Tournaments = new ObservableCollection<Tournament>(db.Tournaments);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };

          
        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }

        public void DeletePlayer(Player e) => Players.Remove(e);
        public void DeleteCountry(Country e) => Countries.Remove(e);
        public void DeleteGender(Gender e) => Genders.Remove(e);
        public void DeleteMatch(Match e) => Matches.Remove(e);
        public void DeletePlace(Place e) => Places.Remove(e);
        public void DeleteTournament(Tournament e) => Tournaments.Remove(e);

        public void CreatePlayer() => Players.Add(new Player() { Age = 0, CountryId = 1, Name = "new", GenderId = 1 });
        public void CreateCountry() => Countries.Add(new Country() { Name = "new"});
        public void CreateGender() => Genders.Add(new Gender() { Name = "new" });
        public void CreateMatch() => Matches.Add(new Match() { Player1Id = 1, Player2Id = 1, Score1 = 0, Score2 = 0, TournamentId = 1 });
        public void CreatePlace() => Places.Add(new Place() { Name = "new" });
        public void CreateTournament() => Tournaments.Add(new Tournament { PlaceId = 1, Name = "new", Time = "01.01.1997" });
     
        public void SQLRequestOpen() => Content = new SQLRequestViewModel();
        public void SQLRequestRun()
        {
            
            using(var db = new dartsContext())
            {
               //Сделать реализацию запросов, через свитч команды(SELECT JOIN и т.д.), в кейсах сам запрос, результат записывать в список запросов
               // Тип списка запросов? Отдельный класс?
            }
            Content = new DataBaseViewModel();
        }
    }
}
