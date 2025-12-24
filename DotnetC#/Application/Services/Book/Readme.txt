┌─────────────────────────────────────────────────────────────────┐
│                    PRESENTATION LAYER                           │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐         │
│  │ Controllers  │  │ Middlewares  │  │  Program.cs  │         │
│  │  - Book      │  │ - Exception  │  │   (Entry)    │         │
│  └──────────────┘  └──────────────┘  └──────────────┘         │
└─────────────────────────────────────────────────────────────────┘
                            ↓ ↑
┌─────────────────────────────────────────────────────────────────┐
│                   APPLICATION LAYER                             │
│  ┌──────────────────┐         ┌──────────────────┐            │
│  │   Services       │         │   Interfaces     │            │
│  │  - BookService   │ ────→   │  - IBookService  │            │
│  └──────────────────┘         └──────────────────┘            │
│  ┌──────────────────┐                                          │
│  │      DTOs        │                                          │
│  │  - CreateBookDto │                                          │
│  │  - CreateImageDto│                                          │
│  └──────────────────┘                                          │
└─────────────────────────────────────────────────────────────────┘
                            ↓ ↑
┌─────────────────────────────────────────────────────────────────┐
│                      DOMAIN LAYER                               │
│  ┌─────────────────────────────────────────────────────────┐  │
│  │              Entities (15 tables)                       │  │
│  │  Book, User, Order, Genre, Image, Review, CartItem,    │  │
│  │  FavoriteBook, Payment, Delivery, Feedback, Role,      │  │
│  │  UserRole, OrdersDetail, ErrorResponse                 │  │
│  └─────────────────────────────────────────────────────────┘  │
│  ┌──────────────────┐         ┌──────────────────┐           │
│  │   Interfaces     │         │   Exceptions     │           │
│  │  - IRepository<T>│         │  - AppException  │           │
│  │  - IBookRepo     │         │  - NotFoundException         │
│  └──────────────────┘         │  - BadRequestException       │
│                                │  - ForbiddenException │      │
│                                └──────────────────┘           │
└─────────────────────────────────────────────────────────────────┘
                            ↓ ↑
┌─────────────────────────────────────────────────────────────────┐
│                  INFRASTRUCTURE LAYER                           │
│  ┌──────────────────┐         ┌──────────────────┐            │
│  │   Repositories   │         │      Data        │            │
│  │  - Repository<T> │ ────→   │  - DbContext     │            │
│  │  - BookRepository│         │  - DbFactory     │            │
│  └──────────────────┘         │  - Migrations    │            │
│                                └──────────────────┘            │
│                                         ↓                      │
│                                   MySQL Database               │
└─────────────────────────────────────────────────────────────────┘
Client Request
    ↓
[BookController] → Validate input, call service
    ↓
[IBookService/BookService] → Business logic
    ↓
[IBookRepository/BookRepository] → Data access với Include()
    ↓
[Repository<T>] → Generic CRUD operations
    ↓
[ApplicationDbContext] → EF Core mapping
    ↓
MySQL Database (15 tables)
    ↓
Return response (JSON)


⚠️ VẤN ĐỀ CẦN FIX
❌ Duplicate Exceptions folder ở root cần xóa
⚠️ QuerySplittingBehavior warning - cần config cho multiple Include()
🔄 Chưa implement: User, Order, Cart, Review services
📝 Thiếu: Authentication/Authorization
📝 Thiếu: Input validation với FluentValidation
📝 Thiếu: AutoMapper cho DTO mapping