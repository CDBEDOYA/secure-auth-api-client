import React, { useEffect, useState } from 'react';
import { View, Text, TextInput, Button, Alert } from 'react-native';
import * as SecureStore from 'expo-secure-store';

export default function App() {
  const [token, setToken] = useState(null);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [profile, setProfile] = useState('');

  const login = async () => {
    const res = await fetch('http://localhost:5000/api/user/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username, password }),
    });
    const data = await res.json();
    if (data.token) {
      await SecureStore.setItemAsync('token', data.token);
      setToken(data.token);
    } else {
      Alert.alert('Login failed');
    }
  };

  const getProfile = async () => {
    const savedToken = await SecureStore.getItemAsync('token');
    const res = await fetch('http://localhost:5000/api/user/profile', {
      headers: { Authorization: `Bearer ${savedToken}` },
    });
    const data = await res.json();
    setProfile(data.username);
  };

  useEffect(() => {
    if (token) getProfile();
  }, [token]);

  return (
    <View style={{ padding: 40 }}>
      {!token ? (
        <>
          <TextInput placeholder="Username" onChangeText={setUsername} style={{ marginBottom: 10 }} />
          <TextInput placeholder="Password" secureTextEntry onChangeText={setPassword} style={{ marginBottom: 10 }} />
          <Button title="Login" onPress={login} />
        </>
      ) : (
        <Text>Welcome, {profile}</Text>
      )}
    </View>
  );
}