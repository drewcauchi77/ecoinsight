import { DarkTheme, ThemeProvider } from "@react-navigation/native";
import { Stack } from "expo-router";

const RootLayout = () => {
    return (
        <ThemeProvider value={DarkTheme}>
            <Stack >
                {/* <Stack.Screen name="(tabs)" options={{ headerShown: false }} /> */}
                <Stack.Screen name="recipe" options={{ title: 'Recipe' }} />
            </Stack>
        </ThemeProvider>
    );
};

export default RootLayout;

// App Background - linear-gradient(340deg, rgba(0,0,0,1) 0%, rgba(28,28,28,1) 70%, rgba(42,42,42,1) 100%);
// Background - #1c1c1c;
// Cards - #ffffff;
// Primary - #dcfd65;