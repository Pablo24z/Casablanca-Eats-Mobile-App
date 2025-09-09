# Casablanca Eats - .NET MAUI Mobile Ordering App

A cross-platform (.NET MAUI, .NET 8) mobile app for a real Caribbean restaurant in London.

**Focus:** usable, accessible ordering with native device features.

## Highlights
- **Ordering UX:** category browsing, basket, validated checkout.
- **Native integrations:** GPS autofill, haptics, shake-to-undo, toast notifications.
- **Accessibility:** WCAG-minded colour contrast, 18sp+ fonts, clear error states, dark mode.
- **Architecture:** MVVM, data binding; tested on Android phones/tablets.

## Tech
`.NET MAUI`, `C#`, `MVVM`, `Android Emulator`, `Visual Studio`.

## Run locally
- Open in Visual Studio 2022 (17.9+), target **Android**.
- Restore dependencies, build, and deploy to emulator/USB device.

## Roadmap
- Payment provider sandbox
- Basic order history (local DB)


## About the App

Casablanca Eats is a polished and accessible .NET MAUI mobile application, designed to work seamlessly across Android phones and tablets.  
The app showcases the restaurant’s story, menu, and ordering experience in an intuitive and friendly user interface that reflects the vibrant, community-driven spirit of the restaurant itself.

This app was developed with real-world usage in mind, with extra attention given to accessibility, hardware integration, and UX detail that makes it feel native and professional.

---

## Key Features

### Core Functionality

- **Menu Browsing**: Users can scroll through beautifully presented categories (Meals, Portions, Snacks, etc.) with tappable dishes and detailed descriptions.
- **Order System**: Dishes can be added to a basket using simple taps or long presses, then taken through to a fully validated checkout process.
- **Basket Page**: Includes real-time updates, cost calculation, and interactive removal — including via shake gesture.

### Hardware Integration

- **GPS Location Autofill**: On checkout, users can tap the GPS icon to automatically fill in their street, city, and postcode.
- **Vibration & Haptic Feedback**: Used when placing orders or adding to the basket to reinforce interaction.
- **Shake Detection**: Shaking the device removes the last item from the basket — a fun and practical feature.
- **Toast Notifications**: Native toast pop-ups are used to deliver confirmations or feedback instead of interruptive alerts.

### Accessibility & WCAG Compliance

Accessibility was a priority throughout, with multiple WCAG 2.1 standards met, including:

- **Minimum font size of 18sp** for key text content
- **High contrast color palette** (tested for colorblind friendliness) — white, yellow (#FECA18), green (#7ECB37), and deep black/grey backgrounds
- **Error handling** with both visual indicators (red fields) and **clear, actionable error messages**
- **Dark mode support** with manual toggle via the StickyNavBar
- **Touch target spacing and navigation consistency**, ensuring easy use on mobile devices

These features ensure the app is usable by a wide audience, including those with visual, cognitive, or motor impairments.

---

## UX & Design Consistency

- Consistent use of brand colors and font (Palanquin family) across all pages for a unified look.
- Custom app icon and splash screen make the app feel complete and trustworthy.
- Responsive layouts ensure proper presentation across phone and tablet, including dynamic nav button changes.

---

## Validation & Error Handling

- Contact and Checkout forms feature regex-based validation for email, card numbers, expiry dates, and more.
- Buttons remain disabled until inputs are complete and valid (e.g., privacy checkbox).
- All user input errors are clearly explained and styled, guiding the user to fix them intuitively.

---

## Code Structure & Architecture

Initially built with a beginner approach, the app later transitioned into a more structured **MVVM (Model-View-ViewModel)** pattern for:

- Better separation of concerns
- Easier testing and reusability
- Cleaner data binding and UI logic

This shift was crucial in keeping the codebase scalable, especially as more features were added.

---

## Cross-Platform Deployment

This app was developed and tested on:

- Android phones
-  Android tablets

Thanks to responsive design, layout elements adapt automatically — for example, popular dishes stack on smaller screens but display side-by-side on tablets.  
The StickyNavBar also adapts: switching between a hamburger menu and full-width navigation based on screen width.

---

## Final Thoughts

This project blends practical mobile development skills with real-world emotional investment. It's not just coursework — it’s a tool designed for a real family business.

Casablanca Eats demonstrates my ability to build apps that are accessible, responsive, and user-first — while integrating modern mobile features in meaningful ways.

Thanks for taking the time to explore this project!

---

This app was built using .NET MAUI (targeting .NET 8), tested on both emulator and physical devices, and committed regularly to GitHub as part of development tracking.

