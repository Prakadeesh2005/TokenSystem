# 🏥 ClinixQueue - Doctor Patient Token Queue System

**ClinixQueue** is a sleek, modern, dark-themed WPF application built using C# and .NET. It helps hospital and clinic receptionists manage patient tokens and queue workflows seamlessly in real time without requiring a database.

---
## ✨ Features

* 🎫 **Automatic Token Generation:** Sequential token numbers (`#001`, `#002`, `#003`...) are generated automatically upon patient registration.
* ⚡ **In-Memory Queue Management:** Utilizes C# `Queue<T>` data structure for fast FIFO (First-In, First-Out) operations.
* 🩺 **Consultation Workflow:** Call the next waiting patient or complete the current visit with a single click.
* 🎨 **Dark Purple Theme UI:** A polished, modern dark-mode aesthetic for reception screens.
* 📢 **Empty Queue Handling:** Dynamically displays status updates when no patients are in line.

---

## 🛠️ Built With

* **Language:** C#
* **Framework:** .NET / WPF (Windows Presentation Foundation)
* **Data Structure:** `Queue<Patient>` (In-memory storage)
* **Styling:** Custom XAML Modern Dark Purple Theme
---

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2022 (with .NET Desktop Development workload installed)
* .NET SDK (6.0 / 7.0 / 8.0 or later)

### Installation & Running

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/YOUR_GITHUB_USERNAME/ClinixQueue.git](https://github.com/YOUR_GITHUB_USERNAME/ClinixQueue.git)
