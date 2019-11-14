import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WalletItemComponent } from './wallet-item.component';

describe('WalletItemComponent', () => {
  let component: WalletItemComponent;
  let fixture: ComponentFixture<WalletItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WalletItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WalletItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
