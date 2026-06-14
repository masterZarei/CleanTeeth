# CleanTeeth - Dental Office Web Service

## English

### Overview
CleanTeeth is a modern web service built with **Clean Architecture** principles for managing dental office operations. This project demonstrates best practices in software architecture, including separation of concerns, dependency injection, and testability.

### Project Structure
The application follows a layered clean architecture pattern:

```
CleanTeeth/
├── CleanTeeth.API           # REST API Layer - Entry point for client requests
├── CleanTeeth.Application   # Application Logic - Use cases and business rules
├── CleanTeeth.Domain        # Domain Layer - Core business entities and interfaces
├── CleanTeeth.Infrastructure # External Services - Implementations of interfaces
├── CleanTeeth.Persistence   # Data Access - Database context and repositories
├── CleanTeeth.Security      # Security Layer - Authentication and authorization
└── CleanTeeth.Test          # Unit Tests - Testing throughout all layers
```

### Architecture Layers

#### 1. **Domain Layer** (`CleanTeeth.Domain`)
- Contains core business entities and domain models
- Defines interfaces and abstract classes
- No dependencies on other layers
- Pure business logic without frameworks

#### 2. **Application Layer** (`CleanTeeth.Application`)
- Implements use cases and application services
- Contains business logic orchestration
- Depends only on the Domain layer
- Handles validation and data transformation

#### 3. **Infrastructure Layer** (`CleanTeeth.Infrastructure`)
- Implements external service integrations
- Third-party libraries and APIs
- Implements interfaces defined in Domain layer
- Loose coupling with other layers

#### 4. **Persistence Layer** (`CleanTeeth.Persistence`)
- Database context and ORM configuration
- Repository pattern implementation
- Data migrations and schema management
- Database access abstraction

#### 5. **Security Layer** (`CleanTeeth.Security`)
- Authentication mechanisms
- Authorization and access control
- Encryption and security utilities
- Token management

#### 6. **API Layer** (`CleanTeeth.API`)
- ASP.NET Core REST API endpoints
- Request/response handling
- HTTP middleware
- Dependency injection configuration

#### 7. **Test Layer** (`CleanTeeth.Test`)
- Unit tests for all layers
- Integration tests
- Test fixtures and mock objects
- Code coverage

### Key Features
✅ Clean Architecture Principles  
✅ Separation of Concerns  
✅ Dependency Injection  
✅ Repository Pattern  
✅ Unit Testable Code  
✅ SOLID Principles  
✅ Security Best Practices  

### Technology Stack
- **Framework:** .NET / ASP.NET Core
- **Language:** C#
- **Architecture:** Clean Architecture
- **License:** MIT License

### Getting Started

#### Prerequisites
- .NET SDK (version specified in project)
- Visual Studio or Visual Studio Code
- Git

#### Clone the Repository
```bash
git clone https://github.com/masterZarei/CleanTeeth.git
cd CleanTeeth
```

#### Build the Project
```bash
dotnet build
```

#### Run Tests
```bash
dotnet test
```

#### Run the Application
```bash
dotnet run --project CleanTeeth.API
```

### Contributing
Contributions are welcome! Please feel free to submit pull requests and open issues for bugs or feature requests.

### License
This project is licensed under the MIT License - see the [LICENSE.txt](LICENSE.txt) file for details.

### Author
- **masterZarei** - Initial work

---

## فارسی

### نمای کلی
CleanTeeth یک سرویس وب مدرن است که بر اساس اصول **معماری تمیز** برای مدیریت عملیات دندانپزشکی طراحی شده است. این پروژه بهترین شیوه‌های معماری نرم‌افزار را نمایش می‌دهد، از جمله جداسازی دغدغه‌ها، تزریق وابستگی و قابل‌آزمایش‌بودن.

### ساختار پروژه
برنامه از یک الگوی معماری لایه‌ای تمیز پیروی می‌کند:

```
CleanTeeth/
├── CleanTeeth.API           # لایه REST API - نقطه ورود برای درخواست‌های کلاینت
├── CleanTeeth.Application   # منطق برنامه - موارد استفاده و قوانین کسب‌وکار
├── CleanTeeth.Domain        # لایه دامنه - موجودیت‌های تجاری اصلی و رابط‌ها
├── CleanTeeth.Infrastructure # سرویس‌های خارجی - پیاده‌سازی رابط‌ها
├── CleanTeeth.Persistence   # دسترسی به داده‌ها - بافت پایگاه داده و مخزن‌ها
├── CleanTeeth.Security      # لایه امنیت - احراز هویت و کنترل دسترسی
└── CleanTeeth.Test          # تست‌های واحد - آزمایش در تمام لایه‌ها
```

### لایه‌های معماری

#### 1. **لایه دامنه** (`CleanTeeth.Domain`)
- شامل موجودیت‌های کسب‌وکار اصلی و مدل‌های دامنه
- تعریف رابط‌ها و کلاس‌های انتزاعی
- بدون وابستگی به لایه‌های دیگر
- منطق کسب‌وکار خالص بدون چارچوب‌ها

#### 2. **لایه برنامه** (`CleanTeeth.Application`)
- پیاده‌سازی موارد استفاده و خدمات برنامه
- شامل هماهنگی منطق کسب‌وکار
- فقط وابسته به لایه دامنه
- مدیریت اعتبارسنجی و تبدیل داده‌ها

#### 3. **لایه زیرساخت** (`CleanTeeth.Infrastructure`)
- پیاده‌سازی ادغام خدمات خارجی
- کتابخانه‌های شخص ثالث و API‌ها
- پیاده‌سازی رابط‌های تعریف‌شده در لایه دامنه
- پیوند شل با لایه‌های دیگر

#### 4. **لایه پایداری** (`CleanTeeth.Persistence`)
- بافت پایگاه داده و تنظیم ORM
- پیاده‌سازی الگوی مخزن
- مهاجرت داده‌ها و مدیریت طرح‌بندی
- انتزاع دسترسی به پایگاه داده

#### 5. **لایه امنیت** (`CleanTeeth.Security`)
- مکانیزم‌های احراز هویت
- کنترل دسترسی و مجوز
- ابزار رمزنگاری و امنیت
- مدیریت توکن

#### 6. **لایه API** (`CleanTeeth.API`)
- نقاط انتهایی REST API در ASP.NET Core
- مدیریت درخواست/پاسخ
- میان‌افزار HTTP
- تنظیم تزریق وابستگی

#### 7. **لایه تست** (`CleanTeeth.Test`)
- تست‌های واحد برای تمام لایه‌ها
- تست‌های ادغام
- تجهیزات تست و اشیاء جعلی
- پوشش کد

### ویژگی‌های کلیدی
✅ اصول معماری تمیز  
✅ جداسازی دغدغه‌ها  
✅ تزریق وابستگی  
✅ الگوی مخزن  
✅ کد قابل‌آزمایش  
✅ اصول SOLID  
✅ بهترین شیوه‌های امنیتی  

### پشته فناوری
- **چارچوب:** .NET / ASP.NET Core
- **زبان:** C#
- **معماری:** معماری تمیز
- **مجوز:** مجوز MIT

### شروع به کار

#### پیش‌نیازها
- .NET SDK (نسخه مشخص‌شده در پروژه)
- Visual Studio یا Visual Studio Code
- Git

#### کلون‌کردن مخزن
```bash
git clone https://github.com/masterZarei/CleanTeeth.git
cd CleanTeeth
```

#### ساخت پروژه
```bash
dotnet build
```

#### اجرای تست‌ها
```bash
dotnet test
```

#### اجرای برنامه
```bash
dotnet run --project CleanTeeth.API
```

### مشارکت
از مشارکت‌های شما استقبال می‌کنیم! لطفاً درخواست‌های pull را ارسال کنید و برای اشکالات یا درخواست‌های ویژگی مسائل را باز کنید.

### مجوز
این پروژه تحت مجوز MIT مجاز است - برای جزئیات به فایل [LICENSE.txt](LICENSE.txt) مراجعه کنید.

### نویسنده
- **masterZarei** - کار اولیه
