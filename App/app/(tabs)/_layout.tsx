import React from 'react';
import { Tabs } from 'expo-router';
import { StyleSheet } from 'react-native';
import { TabItems } from '@/constants/Tabs';
import TabIcon from '@/components/tabs/tab-icon';
import AppText from '@/components/global/app-text';
import { Colors } from '@/constants/Colors';
import { useColorScheme } from '@/hooks/useColorScheme';

const TabLayout = () => {
    const colorScheme = useColorScheme();

    return (
        <Tabs
            screenOptions={{
                tabBarActiveTintColor: Colors[colorScheme ?? 'light'].tint,
                tabBarStyle: style.bar,
                tabBarLabelStyle: style.tabLabel,
            }}>
            {
                TabItems.map((tabItem) => {
                    return (
                        <Tabs.Screen 
                            key={tabItem.name}
                            name={tabItem.name}
                            options={{
                                tabBarLabel: () => <AppText text={tabItem.title} />,
                                tabBarIcon: () => <TabIcon icon={tabItem.icon} />,
                                tabBarActiveBackgroundColor: '#80ef80',
                            }} />
                    )
                })
            }
        </Tabs>
    );
};

export default TabLayout;

const style = StyleSheet.create({
    bar: {
        height: 50,
    },
    tabLabel: {
        fontSize: 11,
        fontFamily: 'Cabin-Regular',
        color: '#fff'
    },
});