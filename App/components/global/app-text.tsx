import React from 'react';
import { StyleSheet, Text } from 'react-native';
import { type I_AppTextProps } from '@/definitions/interfaces';

const AppText: React.FC<I_AppTextProps> = ({ text, type = 'Regular' }) => {
    return (
        <Text style={[
            style.text,
            style[`fontFamily${type}`],
        ]}>{ text }</Text>
    );
};

export default AppText;

const style = StyleSheet.create({
    text: {
        color: '#fff',
        fontSize: 11,
        lineHeight: 20,
        letterSpacing: 0.5,
    },
    fontFamilyRegular: {
        fontFamily: 'Cabin-Regular',
    },
    fontFamilyMedium: {
        fontFamily: 'Cabin-Medium',
    },
    fontFamilySemiBold: {
        fontFamily: 'Cabin-SemiBold',
    },
    fontFamilyBold: {
        fontFamily: 'Cabin-Bold',
    },
});
