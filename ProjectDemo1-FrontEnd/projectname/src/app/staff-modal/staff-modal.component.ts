import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-staff-modal',
  templateUrl: './staff-modal.component.html',
  styleUrls: ['./staff-modal.component.css'],
})
export class StaffModalComponent implements OnInit {
  @Input() staff: any = {};
  @Input() mode: 'create' | 'update' = 'create';
  staffForm: FormGroup;
  errorMessage: string | null = null;

  private apiUrl = 'http://localhost:5046/api/RoomService';

  constructor(
    public activeModal: NgbActiveModal,
    private http: HttpClient,
    private fb: FormBuilder
  ) {
    this.staffForm = this.fb.group({
      staffName: [
        this.staff.staffName || '',
        [Validators.required, Validators.pattern('^[a-zA-Z ]+$')],
      ],
      email: [
        this.staff.email || '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.com$'),
        ],
      ],
      contact: [
        this.staff.contact || '',
        [Validators.required, Validators.pattern('^[0-9]{10}$')],
      ],
      address: [
        this.staff.address || '',
        [Validators.required, Validators.pattern('^[a-zA-Z0-9 ,.-]+$')],
      ], // Added Validators.required here
      rating: [this.staff.rating || '', [Validators.min(0), Validators.max(5)]],
      isAvailable: [this.staff.isAvailable || '', Validators.required],
      aadhar: [
        this.staff.aadhar || '',
        [Validators.required, Validators.pattern('^[0-9]{12}$')],
      ],
      imagePath: [this.staff.imagePath || '', Validators.required],
    });
  }

  ngOnInit(): void {
    // No need to clear validators based on the mode
    if (this.mode === 'update') {
      // Optionally prepopulate the form with staff data for the update mode
      this.staffForm.patchValue(this.staff);
    }
  }

  save(): void {
    if (this.staffForm.invalid) {
      this.staffForm.markAllAsTouched();
      return;
    }

    if (this.mode === 'create') {
      this.http
        .post(`${this.apiUrl}/CreateStaff`, this.staffForm.value)
        .subscribe(
          () => this.close('Staff added successfully!'),
          (error) => (this.errorMessage = 'Error adding staff.')
        );
    } else if (this.mode === 'update') {
      this.http
        .put(
          `${this.apiUrl}/UpdateStaff/${this.staff.id}`,
          this.staffForm.value
        )
        .subscribe(
          () => this.close('Staff updated successfully!'),
          (error) => (this.errorMessage = 'Error updating staff.')
        );
    }
  }

  close(message?: string): void {
    if (message) {
      alert(message);
    }
    this.activeModal.close();
  }
}