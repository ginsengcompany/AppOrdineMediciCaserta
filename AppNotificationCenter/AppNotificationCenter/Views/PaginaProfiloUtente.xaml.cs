﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppNotificationCenter.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppNotificationCenter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaProfiloUtente : ContentPage
	{
	    private ProfiloModelView modelView;
		public PaginaProfiloUtente ()
		{
			InitializeComponent ();
            modelView= new ProfiloModelView();
		    BindingContext = modelView;

		}
	}
}