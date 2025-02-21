﻿using ATB.Infrastructure.Commands;
using OshKUU.ViewModels.BaseViewModels;
using ProjectOshKUU.Data;
using ProjectOshKUU.Data.Services;
using ProjectOshKUU.View.WindowsPanel;
using ProjectOshKUU.ViewModels.BaseViewModels;
using ProjectOshKUU.ViewModels.Korpus1VM;
using ProjectOshKUU.ViewModels.Korpus3VM;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectOshKUU.ViewModels
{
    public class ContentVM3 : AbstractContent
    {
        
        public ContentVM3()
        {
            CurrentPage = new Korpus3Floor1VM(new AudienceService(new AppDbContext()),3,1);
            ButtonInfoCommand = new RelayCommand(CommandMethod, CanCloseApplicationExecat);
            ButtonLangCommand = new RelayCommand(ContentMethod, CanCloseApplicationExecat);
            ButtonCallWindowCommand = new RelayCommand(CallWindowMethod, CanCloseApplicationExecat);
            StaticLanguageClass.SelectRoomDelegate -= x => selectRoomMethod(x);
            StaticLanguageClass.SelectRoomDelegate += x => selectRoomMethod(x);


        }
        private void CallWindowMethod(object obj)
        {
            OsPanel osPanel = new();
            osPanel.ShowDialog();

        }
        private void selectRoomMethod(string room)
        {
            StaticTimerClose.count = 0;
            switch (room)
            {
                case "toilet":
                    CurrentPage = new Korpus1Floor0VM(new AudienceService(new AppDbContext()),3,0);

                    break;
                case "library":
                    CurrentPage = new Korpus1Floor1VM(new AudienceService(new AppDbContext()),3,1);

                    break;
                case "Restaurant":
                    CurrentPage = new Korpus1Floor2VM(new AudienceService(new AppDbContext()),3,2);

                    break;
                case "SingleWindow":
                    CurrentPage = new Korpus1Floor3VM(new AudienceService(new AppDbContext()),3,3);

                    break;
                case "Map":
                    CurrentPage = new Korpus1Floor4VM(new AudienceService(new AppDbContext()),3,4);

                    break;
                default:
                    break;
            }
        }
        private void ContentMethod(object obj)
        {
            StaticTimerClose.count = 0;
            if (StaticLanguageClass.Lang == "RU")
            {
                NameFaculty = "Кыргызско-Узбекский Международный университет";
            }
            else
            {
                NameFaculty = "Кыргыз-Өзбек эл аралык университтети";
            }
            SeectFloorMethod();
        }
       
        private async void CommandMethod(object NumberFlat)
        {
            await Task.Run(async () =>
            {
                floor = Convert.ToInt16(NumberFlat);
                SeectFloorMethod();
            });

        }
        private void SeectFloorMethod()
        {
            switch (floor)
            {
                case 0:
                    CurrentPage = new Korpus3Floor0VM(new AudienceService(new AppDbContext()), 3, 0);
                    break;
                case 1:
                    CurrentPage = new Korpus3Floor1VM(new AudienceService(new AppDbContext()), 3, 1);
                    break;
                case 2:
                    CurrentPage = new Korpus3Floor2VM(new AudienceService(new AppDbContext()), 3, 2);
                    break;
                case 3:
                    CurrentPage = new Korpus3Floor3VM(new AudienceService(new AppDbContext()), 3, 3);
                    break;
                case 4:
                    CurrentPage = new Korpus1Floor4VM(new AudienceService(new AppDbContext()), 3, 1);
                    break;
                default:
                    break;
            }
        }

    }
}
