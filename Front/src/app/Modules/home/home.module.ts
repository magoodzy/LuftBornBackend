import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ...HomeRoutingModule.components

  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule,
    

  ]
})
export class HomeModule { }
