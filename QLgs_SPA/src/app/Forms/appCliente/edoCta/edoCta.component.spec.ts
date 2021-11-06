/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EdoCtaComponent } from './edoCta.component';

describe('EdoCtaComponent', () => {
  let component: EdoCtaComponent;
  let fixture: ComponentFixture<EdoCtaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EdoCtaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EdoCtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
