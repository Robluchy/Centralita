package com.fempa.web.controller;

import com.fempa.web.model.Usuario;
import com.fempa.web.repositorios.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class UsuarioController {
    @Autowired
    private UsuarioRepository usuarioRepository;
    @GetMapping("/users")
    public String users(Usuario usuario, Model model) {
        model.addAttribute("usuarios", usuarioRepository.findAll());
        return "users";
    }
    @GetMapping("/users/delete/{id}")
    public String deleteUser(@PathVariable("id") Integer id, Model model) {
        Usuario usuario = usuarioRepository.findById(Long.valueOf(id))
                .orElseThrow(() -> new IllegalArgumentException("Id de usuario no válido: " + id));;
        if(usuario != null)
            usuarioRepository.delete(usuario);
        return "redirect:/users";
    }
    @GetMapping("/users/edit/{id}")
    public String editUser(@PathVariable("id") Integer id, Model model) {
        Usuario usuario = usuarioRepository.findById(Long.valueOf(id))
                .orElseThrow(() -> new IllegalArgumentException("Id de usuario no válido: " + id));;
        if(usuario != null)
            model.addAttribute("usuario", usuario);
        return "editUser";
    }

    @PostMapping("/users/add")
    public String addUser(Usuario usuario, Model model) {
        usuarioRepository.save(usuario);
        return "redirect:/users";
    }

    @PostMapping("/users/update/{id}")
    public String updateUser(Usuario usuario, Model model) {
        usuarioRepository.save(usuario);
        return "redirect:/users";
    }
}
