# Location Tracker App
Project Overview
This is a Location Tracker application built using .NET MAUI (Multi-platform App UI). The primary goal of this application is to:

Track the user's geographical location in real-time (or near real-time).

Save these location data points to a local SQLite database for persistence.

Display the recorded locations on a map, with the ambitious aim of visualizing them as a "heatmap."

## My Journey as a Novice Developer
This project represents a significant learning curve for me, as I am quite new to C# programming and the .NET MAUI framework. Building a multi-platform application from scratch has been an exciting but mostly challenging experience. Every line of code, every error resolved, and every concept grasped has contributed to my foundational understanding of modern app development.

Key Features (Current Implementation)
Live Location Tracking: The app can continuously fetch and record your current GPS coordinates at set intervals.

Data Persistence: All tracked location points are securely saved to an SQLite database directly on the device, meaning your history remains even after closing the app.

Map Visualization: Locations are displayed on an interactive map using the built-in .NET MAUI Maps component.

"Heatmap" Feature (Work in Progress): My initial ambition was a fully dynamic heatmap where areas with higher densities of points would glow more intensely. As a novice, achieving this advanced rendering proved challenging. Currently, the "heatmap" logic is included, but the implementation lacks desired results. I did attempt to add legacy data points, but struggled to visualize them on my custom map.


Technologies Used
C#: The primary programming language for all application logic.

.NET MAUI: The cross-platform framework used to build native Android, iOS, and Windows applications from a single codebase.

SQLite: A lightweight, embedded relational database used for local data storage.

Android Emulator: Primarily used during development and testing to simulate various Android devices and their location capabilities. The app is also built to target iOS and Windows.

Final Thoughts & Future Enhancements
Developing this Location Tracker has been an immense learning experience. While I'm proud of what I've accomplished as a novice, I recognize there's significant room for growth and improvement, particularly in the "heatmap" functionality.

Here are some ideas for future revisions, after I delve deeper into C# and the .NET MAUI framework:

True Heatmap Implementation: My biggest goal is to implement a genuine heatmap. This would involve researching and integrating advanced mapping libraries or custom drawing techniques that can interpolate data density into a smooth, color-graded visualization, rather than just discrete circles. This might require exploring:

Custom IMapElement renderers.

Third-party MAUI map controls that support heatmap layers.

Potentially integrating a web view with a JavaScript mapping library (like Leaflet or Google Maps JS API) that has robust heatmap plugins.

Performance Optimization: As more data points accumulate, the current method of redrawing all circles might impact performance. Future improvements would focus on:

Optimizing database queries and data loading.

Efficiently updating only changed map elements.

Potentially batching location updates instead of processing each individually.

User Experience (UX) Enhancements:

Adding zoom and pan controls specific to the heatmap data.

Allowing users to filter locations by date/time range.

Providing options to customize heatmap colors or radius.

This project has ignited my passion for app development, and I look forward to refining these features as my skills continue to grow! 
